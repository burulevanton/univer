from concurrent import futures
import time
import grpc

import ad_pb2
import ad_pb2_grpc

import db

_ONE_DAY_IN_SECONDS = 60 * 60 * 24


class AdService(ad_pb2_grpc.AdServiceServicer):
    def SendAd(self, request, context):
        if len(request.title) > 256:
            return ad_pb2.AdReply(message='Длина заголовка не должна превышать 256 символов')
        db.add_ad(request.title, request.text, request.user)
        return ad_pb2.AdReply(message='Обьявление "%s" от пользователя %s добавлено' % (request.title, request.user.name))

    @staticmethod
    def create_int_ad(current_ads, ads):
        for ad in ads:
            int_ad = current_ads.ads.add()
            int_ad.user.name = str(ad[5])
            int_ad.user.email = str(ad[6])
            int_ad.title = str(ad[1])
            int_ad.text = str(ad[2])
            int_ad.date = str(ad[4])

    def GetAds(self, request, context):
        current_ads = ad_pb2.Ads()
        ads = db.get_ads(request)
        self.create_int_ad(current_ads, ads)
        return current_ads

    def GetUserAd(self, request, context):
        current_ads = ad_pb2.Ads()
        self.create_int_ad(current_ads, db.get_user_ads(request))
        return current_ads

    def Sign(self, request, context):
        db.sign(request)
        return ad_pb2.AdReply(message="Вы успешно вошли как %s" % request.name)


def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    ad_pb2_grpc.add_AdServiceServicer_to_server(AdService(), server)
    server.add_insecure_port('[::]:50051')
    server.start()
    try:
        while True:
            time.sleep(_ONE_DAY_IN_SECONDS)
    except KeyboardInterrupt:
        server.stop(0)


if __name__ == '__main__':
    serve()
