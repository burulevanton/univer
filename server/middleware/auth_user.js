import project from '../index'

module.exports = async(req, res, next) => {
    const result = await project.db.query(
        'SELECT Users.id, Users.name,Users.password, Users.phone, Users.email FROM Users, sessions WHERE session_id=$1 AND Users.id=sessions.user_id', [req.session.id]
    )
    if (result.rows.length !== 0)
        req.user = result.rows[0]
    next()
}
