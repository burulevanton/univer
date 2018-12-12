import grpc

import ad_pb2_grpc
import ad_pb2

connection_status = grpc.ChannelConnectivity.IDLE


class Client:

    def __init__(self):
        self.connection_status = grpc.ChannelConnectivity.IDLE
        self.stub = None
        self.user = None

    @property
    def is_connected(self):
        return self.connection_status == grpc.ChannelConnectivity.READY

    def create_ad(self):
        print("Создание объявления")
        ad = ad_pb2.Ad(user=self.user)
        ad.title = input('Введите заголовок объявления:')
        ad.text = input('Введите текст объявления:')
        try:
            response = self.stub.SendAd(ad)
        except grpc.RpcError:
            print('Нет подключения')
        else:
            print(response.message)

    @staticmethod
    def print_ad(ad):
        print()
        print('//////////////////////////////////')
        print('Заголовок: %s' % ad.title)
        print('*********************************')
        print('Описание: %s' % ad.text)
        print('*********************************')
        print('Дата: %s' % ad.date)
        print('Создатель:')
        print('Имя: %s' % ad.user.name)
        print('Email: %s' % ad.user.email)
        print(r'\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\')
        print()

    def get_ads(self):
        try:
            response = self.stub.GetAds(self.user)
        except grpc.RpcError as error:
            print('Нет подключения')
            print(error)
        else:
            for ad in response.ads:
                self.print_ad(ad)

    def get_user_ad(self):
        try:
            response = self.stub.GetUserAd(self.user)
        except grpc.RpcError:
            print("Нет подключения")
        else:
            for ad in response.ads:
                self.print_ad(ad)

    def on_connectivity_change(self, value):
        if self.connection_status == value:
            return
        else:
            if value == grpc.ChannelConnectivity.CONNECTING:
                if not self.connection_status == grpc.ChannelConnectivity.TRANSIENT_FAILURE:
                    print("Устанавливается соединение с сервером")
                    self.connection_status = value
            elif value == grpc.ChannelConnectivity.READY:
                print("Соединение с сервером установлено успешно")
                self.connection_status = value
            elif value == grpc.ChannelConnectivity.TRANSIENT_FAILURE:
                print("Ошибка восстановления соединения с сервером")
                self.connection_status = value
            elif value == grpc.ChannelConnectivity.IDLE:
                print("Соединение потеряно")
                self.connection_status = value

    def main_loop(self):
        while True:
            if self.is_connected:
                print("1) Добавить обьявление")
                print("2) Посмотреть обьявления")
                answer = input('=>')
                if answer == '1':
                    self.create_ad()
                elif answer == '2':
                    if self.is_connected:
                        print('1) Посмотреть все объявления')
                        print('2) Посмотреть свои объявления')
                        answer = input('=>')
                        if answer == '1':
                            self.get_ads()
                        elif answer == '2':
                            self.get_user_ad()
                else:
                    print('Введено неверное число')
            else:
                print('1) Подключиться к другому серверу')
                print('2) Переподключиться к серверу')
                answer = input('=>')
                if answer == '1':
                    self.connect()
                elif answer == '2':
                    self.sign()
                else:
                    print('Введено неверное число')

    def connect(self):
        print("Введите адрес сервера или 0, если использовать стандартный")
        addr = input('=>')
        channel = grpc.insecure_channel('54.164.148.35:50051') if addr == '0' else grpc.insecure_channel(addr)
        channel.subscribe(self.on_connectivity_change)
        self.stub = ad_pb2_grpc.AdServiceStub(channel)
        self.sign()

    def sign(self):
        self.user = ad_pb2.User()
        self.user.name = input("Введите имя:")
        self.user.email = input('Введите email:')
        try:
            response = self.stub.Sign(self.user)
        except grpc.RpcError:
            print('Нет соединения')
        else:
            print(response.message)
        self.main_loop()


if __name__ == '__main__':
    client = Client()
    client.connect()
