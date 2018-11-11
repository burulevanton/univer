import grpc

import ad_pb2_grpc
import ad_pb2


def create_ad(stub, user):
    print("Создание объявления")
    ad = ad_pb2.Ad(user=user)
    ad.title = input('Введите заголовок объявления:')
    ad.text = input('Введите текст объявления:')
    response = stub.SendAd(ad)
    print(response.message)


def print_ad(ad):
    print()
    print('//////////////////////////////////')
    print('Заголовок: %s' % ad.title)
    print('*********************************')
    print('Описание: %s' % ad.text)
    print('*********************************')
    print('Создатель:')
    print('Имя: %s' % ad.user.name)
    print('Email: %s' % ad.user.email)
    print(r'\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\')
    print()


def get_other_ad(stub, user):
    response = stub.GetOthersAd(user)
    for ad in response.ads:
        print_ad(ad)


def get_user_ad(stub, user):
    response = stub.GetUserAd(user)
    for ad in response.ads:
        print_ad(ad)


def run():
    channel = grpc.insecure_channel('35.173.239.89:50051')
    stub = ad_pb2_grpc.AdServiceStub(channel)
    user = ad_pb2.User()
    user.name = input("Введите имя:")
    user.email = input('Введите email:')
    response = stub.Sign(user)
    print(response.message)
    while True:
        print("1) Добавить обьявление")
        print("2) Посмотреть обьявления")
        answer = input('=>')
        if answer == '1':
            create_ad(stub, user)
        elif answer == '2':
            print('1) Посмотреть чужие объявления')
            print('2) Посмотреть свои объявления')
            answer = input('=>')
            if answer == '1':
                get_other_ad(stub, user)
            elif answer == '2':
                get_user_ad(stub, user)
        else:
            print('Введено неверное число')


if __name__ == '__main__':
    run()
