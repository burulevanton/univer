// ConsoleApplication1.cpp : Ётот файл содержит функцию "main". «десь начинаетс€ и заканчиваетс€ выполнение программы.
//

#include <iostream>
#include <GL/freeglut.h>
#include <GL/glut.h>
#include <mmsystem.h>
#include <cstdlib>
#include <Windows.h>
#include <cmath>
#include <math.h>



using namespace std;

#define PI 3.141592653

unsigned char CSG_STATE = '1';
GLfloat torusRotateY = 0.0f;
GLfloat cubeRotateY = 0.0f;
GLfloat spherePosX = 0.0f, spherePosY = 0.0f, spherePosZ = 0.0f;
GLdouble sphereSize = 2.0;

bool shouldRotate = false;


void firstInsideSecond(void(*a)(), void(*b)(), GLenum face, GLenum test) {
	glEnable(GL_DEPTH_TEST);
	glColorMask(GL_FALSE, GL_FALSE, GL_FALSE, GL_FALSE);
	glCullFace(face); // сторона a
	a();
	glDepthMask(GL_FALSE);
	glEnable(GL_STENCIL_TEST);
	glStencilFunc(GL_ALWAYS, 0, 0);
	glStencilOp(GL_KEEP, GL_KEEP, GL_INCR);
	glCullFace(GL_BACK);
	b(); // b лицева€
	glStencilOp(GL_KEEP, GL_KEEP, GL_DECR);
	glCullFace(GL_FRONT);
	b(); // b задн€€
	glDepthMask(GL_TRUE);
	glColorMask(GL_TRUE, GL_TRUE, GL_TRUE, GL_TRUE);

	glStencilFunc(test, 0, 1);
	glDisable(GL_DEPTH_TEST);

	glCullFace(face);
	a(); //a in b
}

void fixDepth(void(*a)()) {
	glColorMask(GL_FALSE, GL_FALSE, GL_FALSE, GL_FALSE);
	glEnable(GL_DEPTH_TEST);
	glDisable(GL_STENCIL_TEST);
	glDepthFunc(GL_ALWAYS);
	a();
	glDepthFunc(GL_LESS);
}

void csg_one(void(*a)()) {
	glEnable(GL_DEPTH_TEST);
	a();
	glDisable(GL_DEPTH_TEST);
}

void csg_or(void(*a)(), void(*b)()) {
	glEnable(GL_DEPTH_TEST);
	a();
	b();
	glDisable(GL_DEPTH_TEST);
}

void csg_and(void(*a)(), void(*b)()) {
	firstInsideSecond(a, b, GL_BACK, GL_NOTEQUAL);
	fixDepth(b);
	firstInsideSecond(b, a, GL_BACK, GL_NOTEQUAL);
	glDisable(GL_STENCIL_TEST);
}

void csg_sub(void(*a)(), void(*b)()) {
	firstInsideSecond(a, b, GL_FRONT, GL_NOTEQUAL);
	fixDepth(b);
	firstInsideSecond(b, a, GL_BACK, GL_EQUAL);
	glDisable(GL_STENCIL_TEST);
}

void display_torus() {
	glPushMatrix();
	{
		GLfloat materialAmbient[] = { 1.0f, 0.0f, 0.0f };
		GLfloat materialDiffuse[] = { 1.0f, 1.0f, 1.0f };
		glMaterialfv(GL_FRONT, GL_AMBIENT, materialAmbient);
		glMaterialfv(GL_FRONT, GL_DIFFUSE, materialDiffuse);
		glTranslatef(0.0f, 0.0f, 0.0f);
		glRotatef(torusRotateY, 0.0f, 1.0f, 0.0f);
		glutSolidTorus(0.5, 2.5, 300, 100);
	}
	glPopMatrix();
	glPushMatrix();
	{
		GLfloat materialAmbient[] = { 0.5f, 0.5f, 0.0f };
		GLfloat materialDiffuse[] = { 1.0f, 1.0f, 1.0f };
		glMaterialfv(GL_FRONT, GL_AMBIENT, materialAmbient);
		glMaterialfv(GL_FRONT, GL_DIFFUSE, materialDiffuse);
		glTranslatef(0.0f, -2.5f, 0.0f);
		glRotatef(torusRotateY+90.0, 0.0f, 1.0f, 0.0f);
		glutSolidTorus(0.25, 1, 300, 100);
	}
	glPopMatrix();
	glPushMatrix();
	{
		GLfloat materialAmbient[] = { 0.0f, 0.5f, 0.5f };
		GLfloat materialDiffuse[] = { 1.0f, 1.0f, 1.0f };
		glMaterialfv(GL_FRONT, GL_AMBIENT, materialAmbient);
		glMaterialfv(GL_FRONT, GL_DIFFUSE, materialDiffuse);
		glTranslatef(0.0f, 2.5f, 0.0f);
		glRotatef(torusRotateY + 90.0, 0.0f, 1.0f, 0.0f);
		glutSolidTorus(0.25, 1, 300, 100);
	}
	glPopMatrix();
	glPushMatrix();
	{
		GLfloat materialAmbient[] = { 0.5f, 0.0f, 0.5f };
		GLfloat materialDiffuse[] = { 1.0f, 1.0f, 1.0f };
		glMaterialfv(GL_FRONT, GL_AMBIENT, materialAmbient);
		glMaterialfv(GL_FRONT, GL_DIFFUSE, materialDiffuse);
		GLfloat sinangle = sin(torusRotateY * PI / 180.0) * -1.0;
		GLfloat cosangle = cos(torusRotateY * PI / 180.0);
		glTranslatef(2.5*cosangle, 0.0f, 2.5*sinangle);
		glRotatef(90.0, 1.0f, 0.0f, 0.0f);
		glutSolidTorus(0.25, 1, 300, 100);
	}
	glPopMatrix();
	glPushMatrix();
	{
		GLfloat materialAmbient[] = { 0.5f, 0.5f, 0.5f };
		GLfloat materialDiffuse[] = { 1.0f, 1.0f, 1.0f };
		glMaterialfv(GL_FRONT, GL_AMBIENT, materialAmbient);
		glMaterialfv(GL_FRONT, GL_DIFFUSE, materialDiffuse);
		GLfloat sinangle = sin(torusRotateY * PI / 180.0);
		GLfloat cosangle = cos(torusRotateY * PI / 180.0)*-1.0;
		glTranslatef(2.5 * cosangle, 0.0f, 2.5 * sinangle);
		glRotatef(90.0, 1.0f, 0.0f, 0.0f);
		glutSolidTorus(0.25, 1, 300, 100);
	}
	glPopMatrix();
	if (shouldRotate)
		torusRotateY += 0.5f;
}

void display_cube() {

	GLfloat materialAmbient[] = { 0.0f, 0.0f, 0.0f };
	GLfloat materialDiffuseFront[] = { 0.5f, 1.0f, 1.0f };
	GLfloat materialDiffuseBack[] = { 1.0f, 0.5f, 1.0f };
	glMaterialfv(GL_FRONT_AND_BACK, GL_AMBIENT, materialAmbient);
	glMaterialfv(GL_FRONT, GL_DIFFUSE, materialDiffuseFront);
	glMaterialfv(GL_BACK, GL_DIFFUSE, materialDiffuseBack);
	glPushMatrix();
	{
		glTranslatef(0.0f, 0.0f, 0.0f);
		glRotatef(cubeRotateY, 0.0f, 1.0f, 0.0f);
		glutSolidCube(3.0);
	}
	glPopMatrix();
}

void display_sphere() {
	GLfloat materialAmbient[] = { 0.3f, 0.5f, 0.3f };
	GLfloat materialDiffuse[] = { 0.0f, 0.0f, 0.0f };
	glMaterialfv(GL_FRONT, GL_AMBIENT, materialAmbient);
	glMaterialfv(GL_FRONT, GL_DIFFUSE, materialDiffuse);
	glPushMatrix();
	{
		glTranslatef(spherePosX, spherePosY, spherePosZ);
		glutSolidSphere(sphereSize, 200, 200);
	}
	glPopMatrix();


}

void display() {


	glLoadIdentity();
	glClearColor(0.3f, 0.3f, 0.3f, 1.0f);
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT | GL_STENCIL_BUFFER_BIT);

	gluLookAt(0.0f, 0.0f, 10.0f, // eye
		0.0f, 0.0f, 0.0f,  // center
		0.0f, 1.0f, 0.0f);

	switch (CSG_STATE) {
	case '1':
		csg_one(display_torus);
		break;
	case '2':
		csg_or(display_cube, display_sphere);
		break;
	case '3':
		csg_sub(display_sphere, display_cube);
		break;
	case '4':
		csg_and(display_sphere, display_cube);
		break;
	default:
		break;
	}

	glFlush();
	glutSwapBuffers();
}

void reshape(int width, int height) {
	glViewport(0, 0, width, height);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(45.0,
		static_cast<GLdouble>(width) / static_cast<GLdouble>(height),
		0.1, 100.0);
	glMatrixMode(GL_MODELVIEW);
}

void keyboard(unsigned char key, int x, int y) {
	if (key == 27) {
		exit(0);
	}
	if (key >= '1' && key <= '5') {
		shouldRotate = false;
		CSG_STATE = key;
	}
	if (key == ',') {
		torusRotateY -= 2.5f;
	}
	if (key == '.') {
		torusRotateY += 2.5f;
	}
	if (key == '[') {
		cubeRotateY -= 0.5f;
	}
	if (key == ']') {
		cubeRotateY += 0.5f;
	}
	if (key == 'q') {
		spherePosZ -= 0.5f;
	}
	if (key == 'e') {
		spherePosZ += 0.5f;
	}
	if (key == 'w') {
		spherePosY += 0.5f;
	}
	if (key == 's') {
		spherePosY -= 0.5f;
	}
	if (key == 'a') {
		spherePosX -= 0.5f;
	}
	if (key == 'd') {
		spherePosX += 0.5f;
	}
	if (key == ' ') {
		shouldRotate = !shouldRotate;
	}
}

int main(int argc, char** argv) {
	glutInit(&argc, argv);
	glutSetOption(GLUT_MULTISAMPLE, 0);
	glutInitDisplayMode(GLUT_DEPTH | GLUT_STENCIL | GLUT_DOUBLE | GLUT_MULTISAMPLE);
	glutInitWindowSize(900, 900);
	glutCreateWindow("lab 6");
	glutDisplayFunc(display);
	glutIdleFunc(display);
	glutReshapeFunc(reshape);
	glutKeyboardFunc(keyboard);
	glEnable(GL_CULL_FACE);

	glEnable(GL_LIGHTING);
	glLightModeli(GL_LIGHT_MODEL_TWO_SIDE, GL_TRUE);
	glEnable(GL_LIGHT0);
	GLfloat lightPosition[] = { 0.0f, 0.0f, 1.0f, 0.0f };
	GLfloat lightAmbientColor[] = { 1.0f, 1.0f, 1.0f };
	GLfloat lightDiffuseColor[] = { 1.0f, 1.0f, 1.0f };
	glLightfv(GL_LIGHT0, GL_POSITION, lightPosition);
	glLightfv(GL_LIGHT0, GL_AMBIENT, lightAmbientColor);
	glLightfv(GL_LIGHT0, GL_DIFFUSE, lightDiffuseColor);
	glutMainLoop();
	return 0;
}