import sys

from OpenGL.GL import *
from OpenGL.GLUT import *


class SquareWindow:

    def __init__(self, width = 900, height = 600, size = 400):
        self._width = width
        self._height = height
        self._size = size

        self._color = [1, 0, 0, 1]
        self._shininess = [30]

        glutInit(sys.argv)
        glutInitDisplayMode(GLUT_RGB | GLUT_DOUBLE | GLUT_DEPTH)
        glutInitWindowSize(self._width, self._height)
        glutInitWindowPosition((glutGet(GLUT_SCREEN_WIDTH) - self._width) // 2,
                               (glutGet(GLUT_SCREEN_HEIGHT) - self._height) // 2)
        glutCreateWindow("Lab5")
        glutKeyboardFunc(self.press_esc)
        glutDisplayFunc(self.draw)
        glutReshapeFunc(self.reshape_func)

    @staticmethod
    def show():
        glutMainLoop()

    @staticmethod
    def press_esc(key, x, y):
        if ord(key) == 27:
            sys.exit(0)

    @property
    def scale(self):
        scale_x = glutGet(GLUT_WINDOW_WIDTH) / self._width
        scale_y = glutGet(GLUT_WINDOW_HEIGHT) / self._height
        return scale_x * scale_y

    def draw(self):
        glClear(GL_COLOR_BUFFER_BIT)
        glEnable(GL_LIGHTING)
        glEnable(GL_LIGHT0)
        glLoadIdentity()
        ambient_color = [1, 1, 1, 1]
        diffuse_color = [1, 1, 1, 1]
        positionLight = [1, 1, 1, 0]
        glLightfv(GL_LIGHT0, GL_AMBIENT, ambient_color)
        glLightfv(GL_LIGHT0, GL_DIFFUSE, diffuse_color)
        glLightfv(GL_LIGHT0, GL_POSITION, positionLight)


        glMaterialfv(GL_FRONT, GL_DIFFUSE, self._color)
        glMaterialfv(GL_FRONT, GL_SPECULAR, self._color)
        glMaterialfv(GL_FRONT, GL_SHININESS, self._shininess)
        glPushMatrix()
        glTranslated(0,0,6)
        glRotated(45,1,1, 0)
        glutSolidTeapot(0.8)
        glPopMatrix()
        glutSwapBuffers()
        glDisable(GL_LIGHT0)

    @staticmethod
    def reshape_func(width, height):
        glMatrixMode(GL_PROJECTION)
        glLoadIdentity()
        glViewport(0, 0, width, height)
        glOrtho(-width / 2, width / 2, -height / 2, height / 2, 0, 1.0)


if __name__ == '__main__':
    sw = SquareWindow()
    sw.show()

