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
    res.render('index', {
        vue_data: {
            showSignIn: true,
            showSignUp: false,
        }
    })
})

route.post('/', async(req, res) => {
    if (req.user) {
        res.redirect('/')
    }

    var userCheck = await project.db.query(
        'SELECT Users.id FROM Users WHERE name=$1 and password =$2', [req.body.name, req.body.password]
    )
    if (userCheck.rows.length == 0) {
        res.render('index', {
            vue_data: {
                showSignIn: true,
                showSignUp: false,
                errorMessage: 'Данные введены неверно'
            }
        })
        return
    }
    await save(req, userCheck.rows[0].id)
    res.redirect('/')
})

module.exports = route