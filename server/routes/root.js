import express from "express"

const route = express.Router()


route.get('/', (req, res) => {
    if (req.user) {
        res.redirect('/profile')
        return
    }
    res.redirect('/signup')
});

module.exports = route