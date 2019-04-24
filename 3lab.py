import sys

from OpenGL.GL import *
from OpenGL.GLUT import *
from OpenGL.GLU import *


class CubeWindow:

    def __init__(self, width=1024, height=768, size=100):
        self._width = width
        self._height = height
        self._size = size
        self._rotate_x = 0.
        self._rotate_y = 0.
        self._is_perspective = True
        self._eye_x = 0
        self._eye_y = 0
        self._eye_z = 0
        self._eye_step = 50

        glutInit(sys.argv)
        glutInitDisplayMode(GLUT_RGB | GLUT_DOUBLE | GLUT_DEPTH)
        glutInitWindowSize(self._width, self._height)
        glutInitWindowPosition((glutGet(GLUT_SCREEN_WIDTH) - self._width) // 2,
                               (glutGet(GLUT_SCREEN_HEIGHT) - self._height) // 2)
        glutCreateWindow("Lab3")
        glutKeyboardFunc(self.press_key)
        glutSpecialFunc(self.special_key)
        glutDisplayFunc(self.draw)
        glutReshapeFunc(self.reshape_func)
        glEnable(GL_DEPTH_TEST)
        glClearColor(1.0, 1.0, 1.0, 1.0)

    @staticmethod
    def show():
        glutMainLoop()

    def press_key(self, key, x, y):
        if ord(key) == 27:
            sys.exit()
        elif ord(key) == 32:
            self._is_perspective = not self._is_perspective
        elif ord(key) == 113: # Q
            self._eye_x -= self._eye_step
        elif ord(key) == 101: # E
            self._eye_x += self._eye_step
        elif ord(key) == 97: # A
            self._eye_y -= self._eye_step
        elif ord(key) == 100: # D
            self._eye_y += self._eye_step
        elif ord(key) == 122: # Z
            self._eye_z -= self._eye_step
        elif ord(key) == 99: # C
            self._eye_z += self._eye_step

        glutPostRedisplay()

    def draw_edge(self, r, g, b):
        glPushMatrix()
        glColor3f(r, g, b)
        glBegin(GL_POLYGON)
        size = self._size / 2
        glVertex3f(size, size, 0)
        glVertex3f(size, -size, 0)
        glVertex3f(-size, -size, 0)
        glVertex3f(-size, size, 0)
        glEnd()
        glPopMatrix()

    def draw(self):
        glClear(GL_COLOR_BUFFER_BIT)
        glClear(GL_DEPTH_BUFFER_BIT)

        self.reshape_func(self._width, self._height)
        size = self._size / 2
        glPushMatrix()
        glTranslatef(0, 0, -5.64*size)
        gluLookAt(self._eye_x, self._eye_y, self._eye_z, 0, 0,  -5.64 * size, 0, 1, 0)

        glRotatef(self._rotate_x, 1.0, 0.0, 0.0)
        glRotatef(self._rotate_y, 0.0, 1.0, 0.0)

        glPushMatrix()
        glTranslatef(0, 0, -size)
        self.draw_edge(0.5, 0.5, 0.5)
        glPopMatrix()

        glPushMatrix()
        glTranslatef(0, 0, size)
        self.draw_edge(0, 0, 1)
        glPopMatrix()

        glPushMatrix()
        glTranslatef(0, size, 0)
        glRotatef(90, 1, 0, 0)
        self.draw_edge(1, 0.5, 0.5)
        glPopMatrix()

        glPushMatrix()
        glTranslatef(0, -size, 0)
        glRotatef(90, 1, 0, 0)
        self.draw_edge(0.5, 1, 0.5)
        glPopMatrix()

        glPushMatrix()
        glTranslatef(size, 0, 0)
        glRotatef(90, 0, 1, 0)
        self.draw_edge(0.5, 0.5, 1)
        glPopMatrix()

        glPushMatrix()
        glTranslatef(-size, 0, 0)
        glRotatef(90, 0, 1, 0)
        self.draw_edge(1, 0, 0)
        glPopMatrix()

        glPopMatrix()

        glutSwapBuffers()

    def reshape_func(self, width, height):
        glLoadIdentity()
        glViewport(0, 0, width, height)
        if self._is_perspective:
            gluPerspective(45.0, width/height, 0.1, 2000)
        else:
            glOrtho(-width/8, width/8, -height/8, height/8, 0, width/2)

    def special_key(self, key, x, y):
        if key == GLUT_KEY_LEFT:
            self._rotate_y -= 1
        if key == GLUT_KEY_UP:
            self._rotate_x -= 1
        if key == GLUT_KEY_RIGHT:
            self._rotate_y += 1
        if key == GLUT_KEY_DOWN:
            self._rotate_x += 1
        glutPostRedisplay()


if __name__ == '__main__':
    cw = CubeWindow()
    cw.show()
