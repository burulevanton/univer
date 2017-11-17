import express from "express"

const route = express.Router()



route.get('/', (req, res) => {
    res.render('profile', {
        vue_data: {
            name: req.user.name,
            password: req.user.password,
            phone: req.user.phone,
            email: req.user.email
        }
    })
})

module.exports = route