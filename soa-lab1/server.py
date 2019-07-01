import socket
from calculator import Calculator

sock = socket.socket()

sock.bind(('', 9090))

sock.listen(1)
while True:
    print("Ожидание подключения")
    conn, addr = sock.accept()
    calc = Calculator()

    print("Подключено", addr)

    data = conn.recv(1024)
    uData = data.decode('utf-8')
    try:
        result = calc.calc(uData)
    except ValueError as err:
        conn.send(str(err).encode('utf-8'))
    else:
        conn.send((uData + '=' + str(result)).encode('utf-8'))

    conn.close()