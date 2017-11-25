import project from './index'
import uuid from 'uuid/v1'


export async function save(req, id) {
    if(req.session.id){
      await project.db.query(
        'DELETE FROM sessions WHERE user_id=$1', [id]
      )
    }
    req.session.id = uuid()

    await project.db.query(
        'INSERT INTO sessions(session_id, user_id) VALUES ($1,$2)', [req.session.id, id]
    )
}

export async function delete_session(req) {
    await project.db.query(
        'DELETE FROM sessions WHERE session_id=$1', [req.session.id]
    )

    req.session = null
}
