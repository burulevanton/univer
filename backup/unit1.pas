unit Unit1;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, pqconnection, sqldb, db, FileUtil, SynHighlighterSQL,
  SynEdit, Forms, Controls, Graphics, Dialogs, DBGrids, ComCtrls, DbCtrls,
  DBExtCtrls, Menus, StdCtrls;

type

  { TForm1 }

  TForm1 = class(TForm)
    DataSourceRawSql: TDataSource;
    RawSqlOpen: TButton;
    RawSqlSave: TButton;
    RawSqlExecute: TButton;
    DataSourceUniversityGroup: TDataSource;
    DataSourceTeacher: TDataSource;
    DataSourceSubject: TDataSource;
    DataSourceStudent: TDataSource;
    DataSourcePerformance: TDataSource;
    DataSourceDepartment: TDataSource;
    DBEditGroupId: TDBEdit;
    DBEditGroupNumber: TDBEdit;
    DBEditGroupDepartmentId: TDBEdit;
    DBEditGroupdStudentsAmount: TDBEdit;
    DBEditGroupAverageScore: TDBEdit;
    DBEditGroupLeader: TDBEdit;
    DBEditTeacherId: TDBEdit;
    DBEditTeacherName: TDBEdit;
    DBEditTeacherSurname: TDBEdit;
    DBEditTeacherPatronymic: TDBEdit;
    DBEditTeacherAcademicTitle: TDBEdit;
    DBEditTeacherIdDepartment: TDBEdit;
    DBEditSubjectId: TDBEdit;
    DBEditSubjectName: TDBEdit;
    DBEditSubjectHoursAmount: TDBEdit;
    DBEditSubjectHoursOfLectures: TDBEdit;
    DBEditSubjectHoursOfPractice: TDBEdit;
    DBEditSubjectNumberOfSemesters: TDBEdit;
    DBGrid1: TDBGrid;
    DBNavigatorGroup: TDBNavigator;
    DBNavigatorTeacher: TDBNavigator;
    DBNavigatorSubject: TDBNavigator;
    DBStudentBirthDate: TDBDateEdit;
    DBEditStudentsId: TDBEdit;
    DBEditStudentIdGroup: TDBEdit;
    DBEditStudentNumberInGroup: TDBEdit;
    DBEditStudentName: TDBEdit;
    DBEditStudentSurname: TDBEdit;
    DBEditStudentPatronymic: TDBEdit;
    DBEditStudentAddress: TDBEdit;
    DBEditStudentAverageScore: TDBEdit;
    DBEditPerformanceIdStudent: TDBEdit;
    DBEditPerformanceIdGroup: TDBEdit;
    DBEditPerformanceIdSubject: TDBEdit;
    DBEditPerformanceIdTeacher: TDBEdit;
    DBEditPerformanceScore: TDBEdit;
    DBEditDepartmentName: TDBEdit;
    DBEditDepartmentHead: TDBEdit;
    DBEditDepartmentPhone: TDBEdit;
    DBEditId: TDBEdit;
    DBGridPerfomance: TDBGrid;
    DBGridDepartment: TDBGrid;
    DBGridStudent: TDBGrid;
    DBGridSubject: TDBGrid;
    DBGridTeacher: TDBGrid;
    DBGridUniversityGroup: TDBGrid;
    DBNavigatorStudents: TDBNavigator;
    DBNavigatorPerformance: TDBNavigator;
    DBNavigatorDepartment: TDBNavigator;
    OpenDialogRawSql: TOpenDialog;
    PageControl1: TPageControl;
    PQConnection1: TPQConnection;
    SaveDialogRawSql: TSaveDialog;
    SQLQueryRawSql: TSQLQuery;
    SQLQueryUniversityGroup: TSQLQuery;
    SQLQueryTeacher: TSQLQuery;
    SQLQuerySubject: TSQLQuery;
    SQLQueryStudent: TSQLQuery;
    SQLQueryPerformance: TSQLQuery;
    SQLQueryDepartment: TSQLQuery;
    SQLTransaction1: TSQLTransaction;
    Department: TTabSheet;
    Performance: TTabSheet;
    Student: TTabSheet;
    Subject: TTabSheet;
    DepartmentEdit: TTabSheet;
    PerformanceEdit: TTabSheet;
    StudentsEdit: TTabSheet;
    SubjectEdit: TTabSheet;
    GroupEdit: TTabSheet;
    RawSql: TTabSheet;
    RawSqlEdit: TSynEdit;
    TeacherEdit: TTabSheet;
    UniversityGroup: TTabSheet;
    Teacher: TTabSheet;
    procedure RawSqlExecuteClick(Sender: TObject);
    procedure RawSqlOpenClick(Sender: TObject);
    procedure RawSqlSaveClick(Sender: TObject);
    procedure SQLQueryDepartmentAfterPost(DataSet: TDataSet);
    procedure SQLQueryPerformanceAfterPost(DataSet: TDataSet);
    procedure SQLQueryStudentAfterPost(DataSet: TDataSet);
    procedure SQLQuerySubjectAfterPost(DataSet: TDataSet);
    procedure SQLQueryTeacherAfterPost(DataSet: TDataSet);
    procedure SQLQueryUniversityGroupAfterPost(DataSet: TDataSet);
  private
    procedure RefreshSql();
  public

  end;

var
  Form1: TForm1;

implementation

{$R *.lfm}


{ TForm1 }
procedure TForm1.RefreshSql();
begin
  self.SQLQueryUniversityGroup.Close();
  self.SQLQueryUniversityGroup.Open();
  self.SQLQueryTeacher.Close();
  self.SQLQueryTeacher.Open();
  self.SQLQuerySubject.Close();
  self.SQLQuerySubject.Open();
  self.SQLQueryStudent.Close();
  self.SQLQueryStudent.Open();
  self.SQLQueryPerformance.Close();
  self.SQLQueryPerformance.Open();
  self.SQLQueryDepartment.Close();
  self.SQLQueryDepartment.Open();
end;

procedure TForm1.SQLQueryDepartmentAfterPost(DataSet: TDataSet);
begin
  self.SQLQueryDepartment.ApplyUpdates(0);
  self.SQLTransaction1.Commit();
  self.RefreshSql();
end;

procedure TForm1.RawSqlOpenClick(Sender: TObject);
begin
   if(self.OpenDialogRawSql.Execute()) then
   begin
     self.RawSqlEdit.Lines.LoadFromFile(self.OpenDialogRawSql.FileName);
   end;
end;

procedure TForm1.RawSqlExecuteClick(Sender: TObject);
begin
   self.SQLQueryRawSql.Close();
   self.SQLQueryRawSql.SQL.Text:=self.RawSqlEdit.Text;
   self.SQLQueryRawSql.Open();
end;

procedure TForm1.RawSqlSaveClick(Sender: TObject);
begin
  if(self.SaveDialogRawSql.Execute()) then
  begin
    self.RawSqlEdit.Lines.SaveToFile(self.SaveDialogRawSql.FileName);
  end;
end;

procedure TForm1.SQLQueryPerformanceAfterPost(DataSet: TDataSet);
begin
  self.SQLQueryPerformance.ApplyUpdates(0);
  self.SQLTransaction1.Commit();
  self.RefreshSql();
end;

procedure TForm1.SQLQueryStudentAfterPost(DataSet: TDataSet);
begin
  self.SQLQueryStudent.ApplyUpdates(0);
  self.SQLTransaction1.Commit();
  self.RefreshSql();
end;

procedure TForm1.SQLQuerySubjectAfterPost(DataSet: TDataSet);
begin
  self.SQLQuerySubject.ApplyUpdates(0);
  self.SQLTransaction1.Commit();
  self.RefreshSql();
end;

procedure TForm1.SQLQueryTeacherAfterPost(DataSet: TDataSet);
begin
  self.SQLQueryTeacher.ApplyUpdates(0);
  self.SQLTransaction1.Commit();
  self.RefreshSql();
end;

procedure TForm1.SQLQueryUniversityGroupAfterPost(DataSet: TDataSet);
begin
  self.SQLQueryUniversityGroup.ApplyUpdates(0);
  self.SQLTransaction1.Commit();
  self.RefreshSql();
end;


end.

