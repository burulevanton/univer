import express from "express"
import path from 'path'
import project from '../index'
import {delete_session, save} from '../session'

const route = express.Router()

route.get('/',
  (req,res)=> {
  res.sendFile(path.join(__dirname,'../index.html'))
  })

route.post('/signin', async(req,res)=>{
  const userCheck = await project.db.query(
    'SELECT Users.id FROM Users WHERE name=$1 and password =$2', [req.body.name, req.body.password]
  )
  if(userCheck.rows.length === 0){
    res.sendStatus(400)
    return
  }
  await save(req,userCheck.rows[0].id)
  res.status(200).send(req.session.id)
})

route.get('/signout', async(req,res) =>{
  await delete_session(req)
  res.sendStatus(200)
})

route.post('/signup', async(req,res)=>{
  const userCheck = await project.db.query(
    "SELECT count(*) FROM Users WHERE name=$1 OR phone=$2 OR email=$3", [req.body.name, req.body.phone, req.body.email]
  )
  if(!(userCheck.rows[0].count ==='0')) {
    res.sendStatus(400)
    return
  }
  const result = await project.db.query(
    'INSERT INTO Users (name, password, phone, email) VALUES ($1,$2,$3,$4) RETURNING id', [req.body.name, req.body.password, req.body.phone, req.body.email]
  )
  await save(req,result.rows[0].id)
  res.status(200).send(req.session.id)
})

route.get('/user', async(req,res)=>{
  if(!req.session.id){
    res.sendStatus(401)
    return
  }
  const result = await project.db.query(
    'SELECT Users.name,Users.password, Users.phone, Users.email FROM Users, sessions WHERE session_id=$1 AND Users.id=sessions.user_id', [req.session.id]
  )
  res.status(200).send(result.rows[0])
})

route.get('/session', (req,res) => {
  if (req.session.id) {
    res.send(req.session.id)
    return
  }
  res.sendStatus(401)
})

module.exports = route
