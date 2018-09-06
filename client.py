import socket


while True:
    sock = socket.socket()
    sock.connect(('soa-lab1.herokuapp.com/', 9090))
    text = input()
    sock.send(text.encode('utf-8'))
    data = sock.recv(1024)
    uData = data.decode('utf-8')
    print('Ответ сервера\n', uData)
    sock.close()