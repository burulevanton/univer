import express from 'express'
import bodyParser from 'body-parser'
import path from 'path'
import morgan from 'morgan'
import pg from 'pg'
import session from 'cookie-session'
import uuid from 'uuid/v1'

const port = process.env.PORT || 5000
const app = express()
const db = pg.Pool({
    user: 'postgres',
    host: 'localhost',
    database: 'web',
    password: '170798',
    port: 5432
})


app.set('view engine', 'hbs')

app.use(bodyParser.urlencoded({ extended: false }))
app.use('/dist', express.static('dist'))
app.use(morgan('tiny'))

app.use(session({
    name: 'session',
    keys: ['id']
}))

//для hot-reload
////////////////////////////////////////////////////////
import webpack from 'webpack'
import webpackMiddleware from 'webpack-dev-middleware'
import webpackHotMiddleware from 'webpack-hot-middleware'
import webpackConfig from '../webpack.config.dev'

if (process.env.NODE_ENV === 'development') {
    const compiler = webpack(webpackConfig)
    app.use(webpackMiddleware(compiler, {
        hot: true,
        publicPath: webpackConfig.output.publicPath,
        noInfo: true
    }))
    app.use(webpackHotMiddleware(compiler))
}
//для hot-reload
//////////////////////////////////////////////////////////

app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname, '../views/index.html'))
})

app.get('/profile', (req, res) => {
    res.sendFile(path.join(__dirname, '../views/profile.html'))
})
app.post('/signup', function(req, res, next) {
    req.session.id = uuid()
    console.log(req.session.id)
    next();
})

app.post("/signup", function(req, res) {
    // db.query(
    //     'INSERT INTO users (name, password, phone, email) VALUES ($1, $2, $3, $4)', [req.body.name, req.body.password, req.body.phoneNumber, req.body.email]
    // )
    res.render('profile', {
        vue_data: {
            name: req.body.name,
            password: req.body.password,
            phone: req.body.phoneNumber,
            email: req.body.email
        }
    })
})

app.listen(port, () => console.log('Server listen on port =', port, 'ENV =', process.env.NODE_ENV))