import express from 'express'
import bodyParser from 'body-parser'
import path from 'path'
import morgan from 'morgan'
import pg from 'pg'
import session from 'cookie-session'
import history from 'connect-history-api-fallback'

const port = process.env.PORT || 5000
const app = express()
const db = pg.Pool({
    user: 'postgres',
    host: 'localhost',
    database: 'web',
    password: '170798',
    port: 5432
})

exports.db = db
const staticFileMiddleware = express.static(path.join(__dirname))

app.use(staticFileMiddleware)
app.use(history())
app.use(staticFileMiddleware)
app.use(bodyParser.json())
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


app.use('/',require('./routes/index'))

app.listen(port, () => console.log('Server listen on port =', port))
