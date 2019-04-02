import sys

from OpenGL.GL import *
from OpenGL.GLUT import *


class SquareWindow:

    def __init__(self, width = 900, height = 600, size = 400):
        self._width = width
        self._height = height
        self._size = size
        glutInit(sys.argv)
        glutInitDisplayMode(GLUT_RGB | GLUT_DOUBLE | GLUT_DEPTH)
        glutInitWindowSize(self._width, self._height)
        glutInitWindowPosition((glutGet(GLUT_SCREEN_WIDTH) - self._width) // 2,
                               (glutGet(GLUT_SCREEN_HEIGHT) - self._height) // 2)
        glutCreateWindow("Lab1")
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
        glClearColor(1.0, 1.0, 1.0, 1.0)
        glClear(GL_COLOR_BUFFER_BIT)
        glColor3f(1.0, 0.0, 0.0)
        glBegin(GL_QUADS)
        size = self._size * self.scale / 2
        glVertex2d(size, size)
        glVertex2d(size, -size)
        glVertex2d(-size, -size)
        glVertex2d(-size, size)
        glEnd()
        glutSwapBuffers()

    @staticmethod
    def reshape_func(width, height):
        glMatrixMode(GL_PROJECTION)
        glLoadIdentity()
        glViewport(0, 0, width, height)
        glOrtho(-width / 2, width / 2, -height / 2, height / 2, 0, 1.0)


if __name__ == '__main__':
    sw = SquareWindow()
    sw.show()

