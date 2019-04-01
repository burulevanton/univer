import sys

from OpenGL.GL import *
from OpenGL.GLUT import *

WIDTH = 900
HEIGHT = 600
SIZE = 400


def press_esc(key, x, y):
    if ord(key) == 27:
        sys.exit(0)


def scale():
    scale_x = glutGet(GLUT_WINDOW_WIDTH) / WIDTH
    scale_y = glutGet(GLUT_WINDOW_HEIGHT) / HEIGHT
    return scale_x * scale_y


def draw():
    glClearColor(1.0, 1.0, 1.0, 1.0)
    glClear(GL_COLOR_BUFFER_BIT)
    glColor3f(1.0, 0.0, 0.0)
    glBegin(GL_QUADS)
    size = SIZE * scale() / 2
    glVertex2d(size, size)
    glVertex2d(size, -size)
    glVertex2d(-size, -size)
    glVertex2d(-size, size)
    glEnd()
    glutSwapBuffers()


def reshape_func(width, height):
    glMatrixMode(GL_PROJECTION)
    glLoadIdentity()
    glViewport(0, 0, width, height)
    glOrtho(-width/2, width/2, -height/2, height/2, 0, 1.0)




if __name__ == '__main__':
    glutInit(sys.argv)
    glutInitDisplayMode(GLUT_RGB | GLUT_DOUBLE | GLUT_DEPTH)
    glutInitWindowSize(WIDTH, HEIGHT)
    glutInitWindowPosition((glutGet(GLUT_SCREEN_WIDTH)-WIDTH) // 2, (glutGet(GLUT_SCREEN_HEIGHT)-HEIGHT) //2)
    glutCreateWindow("Lab1")
    glutKeyboardFunc(press_esc)
    glutDisplayFunc(draw)
    glutReshapeFunc(reshape_func)
    glutMainLoop()
