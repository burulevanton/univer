#include <GL/glut.h>
int light_sample = 1;
int WIDTH = 800;
int HEIGHT = 600;

GLdouble eye_x = 0;
GLdouble eye_y = 0;
GLdouble eye_z = 10;

//GLfloat sphereRotateX = 96.0f;
//GLfloat sphereRotateY = 1.0f;
//GLfloat sphereRotateZ = -159.0f;

GLfloat sphereRotateX = 0.0f;
GLfloat sphereRotateY = 0.0f;
GLfloat sphereRotateZ = 0.0f;

GLfloat positionLight0[] = { 1.0f, 1.0f, 1.0f, 0.0f };

GLUquadricObj* quadObj = gluNewQuadric();

bool material = true;


void init(void)
{
	glClearColor(0.3, 0.3, 0.3, 0.0);
	glEnable(GL_LIGHTING);
	glLightModelf(GL_LIGHT_MODEL_TWO_SIDE, GL_TRUE);
	glEnable(GL_NORMALIZE);
	glEnable(GL_DEPTH_TEST);
}



void reshape(int width, int height)

{
	glViewport(0, 0, width, height);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(45.0, width / height, 0.1, 20.0);
	//glOrtho(-3.0, 3.0, -3.0, 3.0, -20.0, 20.0);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
}



void display(void)

{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	reshape(WIDTH, HEIGHT);
	if (material) {
		GLfloat material_diffuse[] = { 0.4, 0.7, 0.2, 1.0 };
		glMaterialfv(GL_FRONT_AND_BACK, GL_DIFFUSE, material_diffuse);
	}
	else {
		GLfloat material_diffuse[] = { 0.5, 0.5, 0.5, 0.0};
		glMaterialfv(GL_FRONT_AND_BACK, GL_DIFFUSE, material_diffuse);
	}
	if (light_sample == 1)
	{
		GLfloat light0_diffuse[] = { 1.0, 1.0, 1.0 };
		glEnable(GL_LIGHT0);
		glLightfv(GL_LIGHT0, GL_DIFFUSE, light0_diffuse);
		glLightfv(GL_LIGHT0, GL_POSITION, positionLight0);
	}
	if (light_sample == 2)
	{
		GLfloat light1_diffuse[] = { 1.0, 0.5, 1.0 };
		GLfloat light1_position[] = { 0, 0.0, 0.8, 1.0 };
		glEnable(GL_LIGHT1);
		glLightfv(GL_LIGHT1, GL_DIFFUSE, light1_diffuse);
		glLightfv(GL_LIGHT1, GL_POSITION, light1_position);
	}
	if (light_sample == 3)
	{
		GLfloat light3_diffuse[] = { 1.0, 1.0, 1.0 };
		GLfloat light3_position[] = { 0.0, 0.0, 1.0, 1.0 };
		GLfloat light3_spot_direction[] = { 0.0, 0.0, -1.0 };
		glEnable(GL_LIGHT2);
		glLightfv(GL_LIGHT2, GL_DIFFUSE, light3_diffuse);
		glLightfv(GL_LIGHT2, GL_POSITION, light3_position);
		glLightf(GL_LIGHT2, GL_SPOT_CUTOFF, 13.0f);
		glLightfv(GL_LIGHT2, GL_SPOT_DIRECTION, light3_spot_direction);
	}

	gluLookAt(eye_x, eye_y, eye_z,
		0.0, 0.0, 2.0,
		0.0, 1.0, 0.0);

	glPushMatrix();
	glTranslatef(0.0f, 0.0f, 0.0f);
	//glScalef(5.0f, 5.0f, 5.0f);
	glRotatef(sphereRotateX, 1.0f, 0.0f, 0.0f);
	glRotatef(sphereRotateY, 0.0f, 1.0f, 0.0f);
	glRotatef(sphereRotateZ, 0.0f, 0.0f, 1.0f);
	//gluSphere(quadObj, 2, 10000, 10000);
	glutSolidSphere(3, 50, 50);
	glPopMatrix();
	glDisable(GL_LIGHT0);
	glDisable(GL_LIGHT1);
	glDisable(GL_LIGHT2);
	glutSwapBuffers();
}



void keyboard_function(unsigned char key, int x, int y)
{

	if (key == '1')
		light_sample = 1;
	if (key == '2')
		light_sample = 2;
	if (key == '3')
		light_sample = 3;
	if (key == '4')
		light_sample = 0;

	if (key == '5')
		material = true;
	if (key == '6')
		material = false;

	if (key == 'w')
		positionLight0[2] -= 1.0f;
	if (key == 's')
		positionLight0[2] += 1.0f;
	if (key == 'a')
		positionLight0[0] -= 1.0f;
	if (key == 'd')
		positionLight0[0] += 1.0f;
	if (key == 'q')
		positionLight0[1] += 1.0f;
	if (key == 'e')
		positionLight0[1] -= 1.0f;

	glutPostRedisplay();

}

void special_key_func(int key, int x, int y) {
	if (key == GLUT_KEY_UP)
		eye_z -= 1;
	if (key == GLUT_KEY_DOWN)
		eye_z += 1;
	if (key == GLUT_KEY_LEFT)
		eye_x -= 1;
	if (key == GLUT_KEY_RIGHT)
		eye_x += 1;
	if (key == GLUT_KEY_PAGE_UP)
		eye_y += 1;
	if (key == GLUT_KEY_PAGE_DOWN)
		eye_y -= 1;

	glutPostRedisplay();
}



void main(int argc, char** argv)

{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_DEPTH);
	glutInitWindowPosition(50, 100);
	glutInitWindowSize(WIDTH, HEIGHT);
	glutCreateWindow("lab5");
	init();
	glutDisplayFunc(display);
	glutReshapeFunc(reshape);
	glutKeyboardFunc(keyboard_function);
	glutSpecialFunc(special_key_func);
	glutMainLoop();
	gluDeleteQuadric(quadObj);
}