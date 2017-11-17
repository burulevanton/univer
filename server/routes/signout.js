import express from "express"
import { delete_session } from '../session'

const route = express.Router()


route.get('/', async(req, res) => {
    if (req.user)
        await delete_session(req)
    res.redirect('/')
});

module.exports = route