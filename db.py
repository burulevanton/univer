import sqlite3

conn = sqlite3.connect('/home/ubuntu/soa_lab2/db.db', check_same_thread=False)
cursor = conn.cursor()


def sign(user):
    sql = """SELECT * from Users where name = '%s' and email = '%s'""" % (user.name, user.email)
    cursor.execute(sql)
    if len(cursor.fetchall()) == 0:
        sql = """insert into Users (name, email) VALUES (%s, %s)""" % (user.name, user.email)
        cursor.execute(sql)
    conn.commit()


def get_id(user):
    sql = """SELECT * from Users where name = '%s' and email = '%s'""" % (user.name, user.email)
    cursor.execute(sql)
    return cursor.fetchone()[2]


def add_ad(title, text, user):
    sql = """INSERT into Ads (title, text, id_user) VALUES ('%s','%s',%s)""" % (title, text, get_id(user))
    print(sql)
    cursor.execute(sql)
    conn.commit()


def get_other_ads(user):
    sql = """select * from Ads INNER join Users where id_user != %s and id_user=Users.id""" % (get_id(user))
    cursor.execute(sql)
    return cursor.fetchall()


def get_user_ads(user):
    sql = """select * from Ads inner join Users where id_user = %s and id_user=Users.id""" % (get_id(user))
    cursor.execute(sql)
    return cursor.fetchall()
