import sys

from OpenGL.GL import *
from OpenGL.GLUT import *
from OpenGL.GLU import *


class CubeWindow:

    def __init__(self, width=800, height=600, size=100):
        self._width = width
        self._height = height
        self._size = size
        self._eye_x = 0
        self._eye_y = 0
        self._eye_z = 10
        self._light_sample = 1

        self._sphereRotateX = 96.0
        self._sphereRotateY = 1.0
        self._sphereRotateZ = -159.0
        self._position_light0 = [1.0, 1.0, 1.0, 0.0]
        self._quad_obj = gluNewQuadric()

        glutInit(sys.argv)
        glutInitDisplayMode(GLUT_RGB | GLUT_DOUBLE | GLUT_DEPTH)
        glutInitWindowSize(self._width, self._height)
        glutInitWindowPosition((glutGet(GLUT_SCREEN_WIDTH) - self._width) // 2,
                               (glutGet(GLUT_SCREEN_HEIGHT) - self._height) // 2)
        glutCreateWindow("Lab5")
        glutKeyboardFunc(self.press_key)
        glutDisplayFunc(self.draw)
        glutReshapeFunc(self.reshape_func)
        glEnable(GL_DEPTH_TEST)
        glEnable(GL_LIGHTING)
        glEnable(GL_NORMALIZE)
        glClearColor(0.3, 0.3, 0.3, 0.0)

    @staticmethod
    def show():
        glutMainLoop()

    def press_key(self, key, x, y):
        print(key)
        if ord(key) == 27:
            sys.exit()
        elif key == b'w':
            self._sphereRotateX -= 51
        elif key == b's':
            self._sphereRotateX += 51
        elif key == b'd':
            self._sphereRotateZ -= 51
        elif key == b'a':
            self._sphereRotateZ += 51
        elif key == b'q':
            self._sphereRotateY += 51
        elif key == b'e':
            self._sphereRotateY -= 51
        elif key == b'1':
            self._light_sample = 1
        elif key == b'2':
            self._light_sample = 2
        elif key == b'3':
            self._light_sample = 3
        elif key == b'i':
            self._position_light0[2] -= 1
        elif key == b'k':
            self._position_light0[2] += 1
        elif key == b'j':
            self._position_light0[0] -= 1
        elif key == b'l':
            self._position_light0[0] += 1
        elif key == b'u':
            self._position_light0[1] += 1
        elif key == b'o':
            self._position_light0[1] -= 1

        glutPostRedisplay()

    def draw(self):
        glClear(GL_COLOR_BUFFER_BIT)
        glClear(GL_DEPTH_BUFFER_BIT)
        self.reshape_func(self._width, self._height)
        material_diffuse = [1.0, 1.0, 1.0, 1.0]
        glMaterialfv(GL_FRONT_AND_BACK, GL_DIFFUSE, material_diffuse)
        if self._light_sample == 1: # directional
            light0_diffuse = [0.4, 0.7, 0.2]
            light0_direction = [1.0, 1.0, 1.0, 0.0]
            glEnable(GL_LIGHT0)
            glLightfv(GL_LIGHT0, GL_DIFFUSE, light0_diffuse)
            glLightfv(GL_LIGHT0, GL_POSITION, self._position_light0)
        if self._light_sample == 2: # point
            light1_diffuse = [0.4, 0.7, 0.2]
            light1_position = [0.0, 0.0, 20.0, 1.0]
            glEnable(GL_LIGHT1)
            glLightfv(GL_LIGHT1, GL_DIFFUSE, light1_diffuse)
            glLightfv(GL_LIGHT1, GL_POSITION, light1_position)
        if self._light_sample == 3: #projector
            light3_diffuse = [0.4, 0.7, 0.2]
            light3_position = [0.0, 0.0, 20.0, 1.0]
            light3_spot_direction = [0.0, 0.0, -1.0]
            glEnable(GL_LIGHT2)
            glLightfv(GL_LIGHT2, GL_DIFFUSE, light3_diffuse)
            glLightfv(GL_LIGHT2, GL_POSITION, light3_position)
            glLightfv(GL_LIGHT2, GL_DIFFUSE, light3_spot_direction)
            glLightfv(GL_LIGHT2, GL_SPOT_CUTOFF, 2.0)
        gluLookAt(self._eye_x, self._eye_y, self._eye_z,
                  0.0, 0.0, 0.0,
                  0.0, 1.0, 0.0)
        glPushMatrix()
        # glTranslatef(0.0, 0.0, 0.0)
        glScalef(5.0, 5.0, 5.0)
        glRotatef(self._sphereRotateX, 1.0, 0.0, 0.0)
        glRotatef(self._sphereRotateY, 0.0, 1.0, 0.0)
        glRotatef(self._sphereRotateZ, 0.0, 0.0, 1.0)
        gluSphere(self._quad_obj, 0.5, 10000, 10000)
        glPopMatrix()
        glDisable(GL_LIGHT0)
        glDisable(GL_LIGHT1)
        glDisable(GL_LIGHT2)
        glutSwapBuffers()

    def reshape_func(self, width, height):
        glMatrixMode(GL_PROJECTION)
        glLoadIdentity()
        glViewport(0, 0, width, height)
        gluPerspective(45.0, width / height, 0.1, 100)
        glMatrixMode(GL_MODELVIEW)
        glLoadIdentity()
        # if self._is_perspective:
        #     gluPerspective(45.0, width/height, 0.1, 2000)
        # else:
        #     glOrtho(-width/8, width/8, -height/8, height/8, 0, width/2)



if __name__ == '__main__':
    cw = CubeWindow()
    cw.show()
