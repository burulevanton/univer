import express from "express"
import path from "path"
import project from '../index'
import { save } from '../session'

const route = express.Router()

route.get('/', (req, res) => {
    if (req.user) {
        res.redirect('/')
        return
    }
    res.render('index')
})

route.post('/', async(req, res) => {
    if (req.user) {
        res.redirect('/')
        return
    }

    var userCheck = await project.db.query(
        "SELECT count(*) FROM Users WHERE name=$1 OR phone=$2 OR email=$3", [req.body.name, req.body.phoneNumber, req.body.email]
    )
    if (!(userCheck.rows[0].count == '0')) {
        res.render('index', {
            vue_data: {
                showSignIn: true,
                showSignUp: false,
                errorMessage: 'Данный пользователь уже зарегестрирован, войдите'
            }
        })
    }

    var result = await project.db.query(
        'INSERT INTO Users (name, password, phone, email) VALUES ($1,$2,$3,$4) RETURNING id', [req.body.name, req.body.password, req.body.phoneNumber, req.body.email]
    )
    await save(req, result.rows[0].id)
    res.redirect('/')
})

module.exports = route