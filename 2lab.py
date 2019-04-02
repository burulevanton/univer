import sys

from OpenGL.GL import *
from OpenGL.GLUT import *
import numpy as np
from math import radians, cos, sin


class SquareCircleWindow:

    def __init__(self, width=900, height=600, size=400, circle_radius=50, step=5):
        self._width = width
        self._height = height
        self._size = size
        self._circle_radius = circle_radius
        self._circle_pos_x = 0.0
        self._circle_pos_y = 0.0
        self._angle = 0
        self._rotate = False
        self._step = step

        glutInit(sys.argv)
        glutInitDisplayMode(GLUT_RGB | GLUT_DOUBLE | GLUT_DEPTH)
        glutInitWindowSize(self._width, self._height)
        glutInitWindowPosition((glutGet(GLUT_SCREEN_WIDTH) - self._width) // 2,
                               (glutGet(GLUT_SCREEN_HEIGHT) - self._height) // 2)
        glutCreateWindow("Lab2")
        glutKeyboardFunc(self.press_esc)
        glutMouseFunc(self.mouse)
        glutSpecialFunc(self.special_key)
        glutIdleFunc(self.handle_idle)
        glutDisplayFunc(self.draw)
        glutReshapeFunc(self.reshape_func)

    @staticmethod
    def show():
        glutMainLoop()

    @staticmethod
    def press_esc(key, x, y):
        if ord(key) == 27:
            sys.exit()

    @property
    def scale(self):
        scale_x = glutGet(GLUT_WINDOW_WIDTH) / self._width
        scale_y = glutGet(GLUT_WINDOW_HEIGHT) / self._height
        return scale_x * scale_y

    def draw_square(self):
        glPushMatrix()
        glColor3f(1.0, 0.0, 0.0)
        glRotatef(self._angle, 0, 0, 1)
        glBegin(GL_QUADS)
        size = self._size * self.scale / 2
        glVertex2d(size, size)
        glVertex2d(size, -size)
        glVertex2d(-size, -size)
        glVertex2d(-size, size)
        glEnd()
        glPopMatrix()

    def draw_circle(self):
        glPushMatrix()
        glColor3f(0.0, 1.0, 0.0)
        x = glutGet(GLUT_WINDOW_WIDTH) / 2 - self._circle_radius + self._circle_pos_x
        y = glutGet(GLUT_WINDOW_HEIGHT) / 2 - self._circle_radius + self._circle_pos_y
        glTranslate(x, y, 0)
        glBegin(GL_POLYGON)
        for grad in np.linspace(0, 360, 100):
            rad = radians(grad)
            x = self._circle_radius * cos(rad)
            y = self._circle_radius * sin(rad)
            glVertex2d(x, y)
        glEnd()
        glPopMatrix()

    def draw(self):
        glClearColor(1.0, 1.0, 1.0, 1.0)
        glClear(GL_COLOR_BUFFER_BIT)
        self.draw_square()
        self.draw_circle()
        glutSwapBuffers()

    @staticmethod
    def reshape_func(width, height):
        glMatrixMode(GL_PROJECTION)
        glLoadIdentity()
        glViewport(0, 0, width, height)
        glOrtho(-width / 2, width / 2, -height / 2, height / 2, 0, 1.0)

    def mouse(self, button, state, x, y):
        if button == GLUT_LEFT_BUTTON:
            self._rotate = True
        elif button == GLUT_RIGHT_BUTTON:
            self._rotate = False

    def special_key(self, key, x, y):
        if key == GLUT_KEY_LEFT:
            self._circle_pos_x -= self._step
        if key == GLUT_KEY_UP:
            self._circle_pos_y += self._step
        if key == GLUT_KEY_RIGHT:
            self._circle_pos_x += self._step
        if key == GLUT_KEY_DOWN:
            self._circle_pos_y -= self._step
        glutPostRedisplay()

    def handle_idle(self):
        if self._rotate:
            self._angle += 1
            glutPostRedisplay()


if __name__ == '__main__':
    scw = SquareCircleWindow()
    scw.show()
