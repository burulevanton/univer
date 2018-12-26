from spyne import Application
from spyne.protocol.soap import Soap11
from spyne.protocol.xml import XmlDocument
from spyne.server.wsgi import WsgiApplication
from service import GlobalTextAnalyzer

application = Application([GlobalTextAnalyzer],
                          tns='globalTextAnalyzer',
                          in_protocol = Soap11(validator='lxml'),
                          out_protocol=Soap11(),
                          name="GlobalTextAnalyzer"
                          )
if __name__ == '__main__':
    from wsgiref.simple_server import make_server

    wsgi_app = WsgiApplication(application)
    server = make_server('0.0.0.0', 9000, wsgi_app)
    server.serve_forever()
