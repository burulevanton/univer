import sys

from OpenGL.GL import *
from OpenGL.GLUT import *
import numpy as np
from math import radians, cos, sin

WIDTH = 900
HEIGHT = 600
SIZE = 400
CIRCLE_RADIUS = 50
ROTATE = False
CIRCLE_POS_X = 0.0
CIRCLE_POS_Y = 0.0
STEP = 5
ANGLE = 0


def press_esc(key, x, y):
    if ord(key) == 27:
        sys.exit(0)


def scale():
    scale_x = glutGet(GLUT_WINDOW_WIDTH) / WIDTH
    scale_y = glutGet(GLUT_WINDOW_HEIGHT) / HEIGHT
    return scale_x * scale_y


def draw_square():
    glPushMatrix()
    glColor3f(1.0, 0.0, 0.0)
    glRotatef(ANGLE, 0, 0, 1)
    glBegin(GL_QUADS)
    size = SIZE * scale() / 2
    glVertex2d(size, size)
    glVertex2d(size, -size)
    glVertex2d(-size, -size)
    glVertex2d(-size, size)
    glEnd()
    glPopMatrix()


def draw_circle():
    glPushMatrix()
    glColor3f(0.0, 1.0, 0.0)
    x = glutGet(GLUT_WINDOW_WIDTH) / 2 - CIRCLE_RADIUS + CIRCLE_POS_X
    y = glutGet(GLUT_WINDOW_HEIGHT) / 2 - CIRCLE_RADIUS + CIRCLE_POS_Y
    glTranslate(x, y, 0)
    glBegin(GL_POLYGON)
    for grad in np.linspace(0, 360, 100):
        rad = radians(grad)
        x = CIRCLE_RADIUS * cos(rad)
        y = CIRCLE_RADIUS * sin(rad)
        glVertex2d(x, y)
    glEnd()
    glPopMatrix()


def draw():
    glClearColor(1.0, 1.0, 1.0, 1.0)
    glClear(GL_COLOR_BUFFER_BIT)
    draw_square()
    draw_circle()
    glutSwapBuffers()


def reshape_func(width, height):
    glMatrixMode(GL_PROJECTION)
    glLoadIdentity()
    glViewport(0, 0, width, height)
    glOrtho(-width/2, width/2, -height/2, height/2, 0, 1.0)


def mouse(button, state, x, y):
    global ROTATE
    if button == GLUT_LEFT_BUTTON:
        ROTATE = True
    elif button == GLUT_RIGHT_BUTTON:
        ROTATE = False


def special_key(key, x, y):
    global CIRCLE_POS_X
    global CIRCLE_POS_Y
    if key == GLUT_KEY_LEFT:
        CIRCLE_POS_X -= STEP
    if key == GLUT_KEY_UP:
        CIRCLE_POS_Y += STEP
    if key == GLUT_KEY_RIGHT:
        CIRCLE_POS_X += STEP
    if key == GLUT_KEY_DOWN:
        CIRCLE_POS_Y -= STEP
    glutPostRedisplay()


def handle_idle():
    if ROTATE:
        global ANGLE
        ANGLE += 1
        glutPostRedisplay()




if __name__ == '__main__':
    glutInit(sys.argv)
    glutInitDisplayMode(GLUT_RGB | GLUT_DOUBLE | GLUT_DEPTH)
    glutInitWindowSize(WIDTH, HEIGHT)
    glutInitWindowPosition((glutGet(GLUT_SCREEN_WIDTH)-WIDTH) // 2, (glutGet(GLUT_SCREEN_HEIGHT)-HEIGHT) //2)
    glutCreateWindow("Lab2")
    glutKeyboardFunc(press_esc)
    glutMouseFunc(mouse)
    glutSpecialFunc(special_key)
    glutIdleFunc(handle_idle)
    glutDisplayFunc(draw)
    glutReshapeFunc(reshape_func)
    glutMainLoop()
