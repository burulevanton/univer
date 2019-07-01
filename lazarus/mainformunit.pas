unit MainFormUnit;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, pqconnection, sqldb, db, FileUtil, SynHighlighterSQL,
  SynEdit, Forms, Controls, Graphics, Dialogs, DBGrids, ComCtrls, DbCtrls,
  DBExtCtrls, Menus, StdCtrls, PairSplitter, Buttons, ExtCtrls,
  FormRawSqlParamUnit, TADbSource, TAGraph, TARadialSeries, TASeries, LR_Class,
  LR_DBSet, LR_BarC, fpspreadsheet, fpsTypes, xlsbiff8, fpsutils, SettingsUnit;

type

  { TMainForm }

  TMainForm = class(TForm)
    ButtonAdd: TButton;
    ButtonEdit: TButton;
    ButtonPassword: TButton;
    ButtonDelete: TButton;
    Chart1: TChart;
    Chart1LineSeries1: TLineSeries;
    Chart2: TChart;
    Chart2BarSeries1: TBarSeries;
    DataSourceUsers: TDataSource;
    DataSourceRoles: TDataSource;
    DataSourceSubjectChart: TDataSource;
    DataSourceGRoupChart: TDataSource;
    DbChartGroup: TDbChartSource;
    DbChartSourceSubject: TDbChartSource;
    ImageBackground: TImage;
    ListBoxUsers: TListBox;
    MainMenu1: TMainMenu;
    MenuItemSettings: TMenuItem;
    MenuItemMain: TMenuItem;
    MenuItemExport: TMenuItem;
    MenuItemImport: TMenuItem;
    MenuItemRefresh: TMenuItem;
    MenuItemQuit: TMenuItem;
    OpenDialogExcel: TOpenDialog;
    PairSplitter1: TPairSplitter;
    PairSplitterSide1: TPairSplitterSide;
    PairSplitterSide2: TPairSplitterSide;
    RadioGroupUsersRoles: TRadioGroup;
    ReportDepartment: TButton;
    ButtonRawDoubleSqlExecute: TButton;
    DataSourceRawDoubleSqlSecond: TDataSource;
    DataSourceRawDoubleSqlMain: TDataSource;
    DataSourceRawSql: TDataSource;
    DBGridRawDoubleSql: TDBGrid;
    frBarCodeObject1: TfrBarCodeObject;
    frDBDataSetTeacher: TfrDBDataSet;
    frDBDataSetPerformance: TfrDBDataSet;
    frDBDataSetDepartment: TfrDBDataSet;
    frReportTeacher: TfrReport;
    frReportPerformance: TfrReport;
    frReportDepartment: TfrReport;
    RawSqlParams: TButton;
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
    ReportTeacher: TButton;
    ReportPerformance: TButton;
    SaveDialogExcel: TSaveDialog;
    SaveDialogRawSql: TSaveDialog;
    SQLQueryUsers: TSQLQuery;
    SQLQueryRoles: TSQLQuery;
    SQLQuerySubjectChart: TSQLQuery;
    SQLQueryGroupChart: TSQLQuery;
    SQLQueryPerformanceView: TSQLQuery;
    SQLQueryRawDoubleSqlSecond: TSQLQuery;
    SQLQueryRawDoubleSqlMain: TSQLQuery;
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
    SynRawDoubleSqlMain: TSynEdit;
    SyncRawDoubleSqlSecond: TSynEdit;
    SynSQLSyn1: TSynSQLSyn;
    RawDoubleSql: TTabSheet;
    TabSheetUsers: TTabSheet;
    TeacherEdit: TTabSheet;
    UniversityGroup: TTabSheet;
    Teacher: TTabSheet;
    procedure ButtonAddClick(Sender: TObject);
    procedure ButtonDeleteClick(Sender: TObject);
    procedure ButtonEditClick(Sender: TObject);
    procedure ButtonPasswordClick(Sender: TObject);
    procedure ButtonRawDoubleSqlExecuteClick(Sender: TObject);
    procedure FormClose(Sender: TObject; var CloseAction: TCloseAction);
    procedure FormShow(Sender: TObject);
    procedure ListBoxUsersClick(Sender: TObject);
    procedure ListBoxUsersSelectionChange(Sender: TObject; User: boolean);
    procedure MenuItemExportClick(Sender: TObject);
    procedure MenuItemImportClick(Sender: TObject);
    procedure MenuItemQuitClick(Sender: TObject);
    procedure MenuItemRefreshClick(Sender: TObject);
    procedure MenuItemSettingsClick(Sender: TObject);
    procedure RadioGroupUsersRolesSelectionChanged(Sender: TObject);
    procedure RawSqlExecuteClick(Sender: TObject);
    procedure RawSqlOpenClick(Sender: TObject);
    procedure RawSqlParamsClick(Sender: TObject);
    procedure RawSqlSaveClick(Sender: TObject);
    procedure ReportDepartmentClick(Sender: TObject);
    procedure ReportPerformanceClick(Sender: TObject);
    procedure ReportTeacherClick(Sender: TObject);
    procedure SQLQueryDepartmentAfterPost(DataSet: TDataSet);
    procedure SQLQueryPerformanceAfterPost(DataSet: TDataSet);
    procedure SQLQueryStudentAfterPost(DataSet: TDataSet);
    procedure SQLQuerySubjectAfterPost(DataSet: TDataSet);
    procedure SQLQueryTeacherAfterPost(DataSet: TDataSet);
    procedure SQLQueryUniversityGroupAfterPost(DataSet: TDataSet);
  private
    UserRole:string;
    PreventRadioGroupUsersRolesRefresh: boolean;
    procedure RefreshSql();
    procedure RefreshSettings();
  public

  end;

var
  MainForm: TMainForm;

resourcestring

  MessageAddUserCaption = 'Add user';
  MessageAddUserText = 'Enter user name';
  MessageChangePasswordCaption = 'Change password';
  MessageChangePasswordText = 'Enter new password';
  MessageRenameUserCaption = 'Rename user';
  MessageRenameUserText = 'Enter new user name';
  MessageDeleteUserCaption = 'Delete user';
  MessageDeleteUserText = 'Are you sure?';
  RadioGroupUsersRolesAdmin = 'Admin';
  RadioGroupUsersRolesOperator = 'Operator';
  RadioGroupUsersRolesUser = 'User';

implementation

{$R *.lfm}


{ TMainForm }
procedure TMainForm.RefreshSettings();
begin
  self.Font := FormSettings.FontDialogFont.Font;
  self.Color:= FormSettings.ColorDialogForm.Color;
   if FileExists(FormSettings.OpenDialogBackground.FileName) then
    self.ImageBackground.Picture.LoadFromFile(FormSettings.OpenDialogBackground.FileName)
  else
    self.ImageBackground.Picture.Clear();
end;

procedure TMainForm.RefreshSql();
var
  i: Integer;
   prevSelectedUser: Integer;
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
  self.SQLQueryGroupChart.Close();
  self.SQLQueryGroupChart.Open();

  if(self.UserRole = 'role_admin') then
  begin
        self.RadioGroupUsersRoles.Enabled:=false;
        self.RadioGroupUsersRoles.ItemIndex:=-1;
        self.ButtonEdit.Enabled:=false;
        self.ButtonDelete.Enabled:=false;

        self.SQLQueryUsers.Close();
        self.SQLQueryUsers.Open();

        prevSelectedUser := self.ListBoxUsers.ItemIndex;
        self.ListBoxUsers.ItemIndex:=-1;
        self.ListBoxUsers.Items.Clear();

        self.DataSourceUsers.DataSet.First();
        for i:=0 to self.DataSourceUsers.DataSet.RecordCount -1 do
        begin
          self.ListBoxUsers.Items.Add(self.DataSourceUsers.DataSet.Fields[0].AsString);
          self.DataSourceUsers.DataSet.Next();
          if(i = prevSelectedUser) then
          self.ListBoxUsers.ItemIndex:=i;
        end;
  end;
end;

procedure TMainForm.SQLQueryDepartmentAfterPost(DataSet: TDataSet);
begin
  self.SQLQueryDepartment.ApplyUpdates(0);
  self.SQLTransaction1.Commit();
  self.RefreshSql();
end;

procedure TMainForm.RawSqlOpenClick(Sender: TObject);
begin
   if(self.OpenDialogRawSql.Execute()) then
   begin
     self.RawSqlEdit.Lines.LoadFromFile(self.OpenDialogRawSql.FileName);
   end;
end;

procedure TMainForm.RawSqlParamsClick(Sender: TObject);
var
  form:TFormRawSqlParam;
begin
   Application.CreateForm(TFormRawSqlParam, form);
   self.SQLQueryRawSql.SQL.Text:=self.RawSqlEdit.Text;
   form.Reload(self.SQLQueryRawSql.Params);
   if(form.ShowModal() = 1) then
   begin
     form.Fill(self.SQLQueryRawSql);
   end;
   form.Destroy();
end;

procedure TMainForm.RawSqlExecuteClick(Sender: TObject);
begin
   self.SQLQueryRawSql.Close();
   self.SQLQueryRawSql.SQL.Text:=self.RawSqlEdit.Text;
   self.SQLQueryRawSql.Open();
end;

procedure TMainForm.ButtonRawDoubleSqlExecuteClick(Sender: TObject);
begin
   self.SQLQueryRawDoubleSqlMain.Close();
   self.SQLQueryRawDoubleSqlSecond.Close();
   self.SQLQueryRawDoubleSqlMain.SQL.Text := self.SynRawDoubleSqlMain.Text;
   self.SQLQueryRawDoubleSqlSecond.SQL.Text := self.SyncRawDoubleSqlSecond.Text;
   self.SQLQueryRawDoubleSqlSecond.Open();
   self.SQLQueryRawDoubleSqlMain.Open();
end;

procedure TMainForm.FormClose(Sender: TObject; var CloseAction: TCloseAction);
begin
  Application.Terminate();
end;

procedure TMainForm.ButtonAddClick(Sender: TObject);
var userName: string;
begin
     userName:=InputBox(MessageAddUserCaption, MessageAddUserText,'');
     if not (userName = '') then
     begin
       self.PQConnection1.ExecuteDirect('CREATE USER "' + userName + '";');
       self.SQLTransaction1.Commit();
       self.RefreshSql();
     end;
end;

procedure TMainForm.ButtonDeleteClick(Sender: TObject);
begin
  if MessageDlg(MessageDeleteUserCaption, MessageDeleteUserText, mtConfirmation, [mbNo, mbYes], 0) = mrYes then
  begin
    self.PQConnection1.ExecuteDirect('DROP ROLE "' + self.ListBoxUsers.Items[self.ListBoxUsers.ItemIndex] + '";');
    self.SQLTransaction1.Commit();
    self.RefreshSql();
  end;
end;

procedure TMainForm.ButtonEditClick(Sender: TObject);
var userName:string;
begin
   userName:=InputBox(MessageRenameUserCaption, MessageRenameUserText,'');
   if not (userName = '') then
   begin
     self.PQConnection1.ExecuteDirect('ALTER ROLE "' + self.ListBoxUsers.Items[self.ListBoxUsers.ItemIndex] + '" RENAME TO "' + userName + '";');
     self.SQLTransaction1.Commit();
     self.RefreshSql();
   end;
end;

procedure TMainForm.ButtonPasswordClick(Sender: TObject);
var
  password: string;
begin
   password := PasswordBox(MessageChangePasswordCaption, MessageChangePasswordText);
   if not (password = '') then
   begin
     self.PQConnection1.ExecuteDirect('ALTER ROLE "' + self.ListBoxUsers.Items[self.ListBoxUsers.ItemIndex] + '" PASSWORD ''' + password + ''';');
     self.SQLTransaction1.Commit();
     self.RefreshSql();
   end;
end;

procedure TMainForm.FormShow(Sender: TObject);
begin
  self.RefreshSettings();
  self.PQConnection1.Connected:=true;
  self.SQLQueryDepartment.Active:=true;
  self.SQLQueryGroupChart.Active:=true;
  self.SQLQueryPerformance.Active:=true;
  self.SQLQueryPerformanceView.Active:=true;
  self.SQLQueryStudent.Active:=true;
  self.SQLQuerySubject.Active:=true;
  self.SQLQuerySubjectChart.Active:=true;
  self.SQLQueryTeacher.Active:=true;
  self.SQLQueryUniversityGroup.Active:=true;


  self.SQLQueryRoles.ParamByName('username').AsString:=self.PQConnection1.UserName;
  self.SQLQueryRoles.Active:=true;

  self.DataSourceRoles.DataSet.First();
  self.UserRole:=self.DataSourceRoles.DataSet.Fields[0].AsString;
  self.Caption:='Connected ' + self.PQConnection1.UserName + ' as ' + self.UserRole.Substring(5);
  if(self.UserRole = 'role_user') then
  begin
    self.DepartmentEdit.TabVisible:=false;
    self.PerformanceEdit.TabVisible:=false;
    self.StudentsEdit.TabVisible:=false;
    self.SubjectEdit.TabVisible:=false;
    self.TeacherEdit.TabVisible:=false;
    self.GroupEdit.TabVisible:=false;
  end;
  if(self.UserRole = 'role_admin') then
  begin
       self.SQLQueryUsers.Active:=true;
       self.RadioGroupUsersRoles.Items.Clear();
       self.RadioGroupUsersRoles.Items.Add(RadioGroupUsersRolesAdmin);
       self.RadioGroupUsersRoles.Items.Add(RadioGroupUsersRolesOperator);
       self.RadioGroupUsersRoles.Items.Add(RadioGroupUsersRolesUser);
  end
  else
  begin
       self.TabSheetUsers.TabVisible:=false;
  end;
self.RefreshSql();
end;

procedure TMainForm.ListBoxUsersClick(Sender: TObject);
begin
  self.PreventRadioGroupUsersRolesRefresh:=true;
  self.RadioGroupUsersRoles.Enabled:=true;
  self.ButtonPassword.Enabled:=true;
  self.ButtonDelete.Enabled:=true;
  self.ButtonEdit.Enabled:=true;
  self.RadioGroupUsersRoles.ItemIndex:=-1;

  if(self.ListBoxUsers.ItemIndex = -1) then
  begin
       self.RadioGroupUsersRoles.ItemIndex:=-1;
       self.RadioGroupUsersRoles.Enabled:=false;
       self.ButtonDelete.Enabled:=false;
       self.ButtonEdit.Enabled:=false;
       self.ButtonPassword.Enabled:=false;
  end
  else
  begin
    self.SQLQueryRoles.ParamByName('username').AsString:=self.ListBoxUsers.Items[self.ListBoxUsers.ItemIndex];
    self.SQLQueryRoles.Close();
    self.SQLQueryRoles.Open();

    if(self.DataSourceRoles.DataSet.Fields[0].AsString = 'role_admin') then
    self.RadioGroupUsersRoles.ItemIndex:=0;
    if(self.DataSourceRoles.DataSet.Fields[0].AsString = 'role_operator') then
    self.RadioGroupUsersRoles.ItemIndex:=1;
    if(self.DataSourceRoles.DataSet.Fields[0].AsString = 'role_user') then
    self.RadioGroupUsersRoles.ItemIndex:=2;

    if (self.ListBoxUsers.Items[self.ListBoxUsers.ItemIndex] = self.PQConnection1.UserName) then
    begin
         self.RadioGroupUsersRoles.Enabled:=false;
         self.ButtonDelete.Enabled:=false;
         self.ButtonEdit.Enabled:=false;
    end;
  end;
  self.PreventRadioGroupUsersRolesRefresh:=false;
end;

procedure TMainForm.ListBoxUsersSelectionChange(Sender: TObject; User: boolean);
begin
  self.ListBoxUsers.Click();
end;

procedure DataSourceToWorksheet(ds: TDataSource; ws: TsWorksheet; header: TStringList);
var
  row, column: Integer;
  ft: TFieldType;
begin
  ds.DataSet.First();
  for column := 0 to header.Count -1 do
  begin
    ws.AddCell(0, column);
    ws.WriteText(0, column, header[column]);
    ws.WriteFontStyle(0, column, [fssBold]);
  end;
  for row := 0 to ds.DataSet.RecordCount - 1 do
  begin
    for column := 0 to ds.DataSet.FieldCount - 1 do
    begin
      ws.AddCell(row + 1, column);
      ft := ds.DataSet.Fields[column].DataType;
      if (ft = ftSmallint) or
         (ft = ftInteger) or
         (ft = ftWord) or
         (ft = ftFloat) or
         (ft = ftCurrency) or
         (ft = ftBCD) or
         (ft = ftLargeint) then
         ws.WriteNumber(row + 1, column,  ds.DataSet.Fields[column].AsFloat)
      else
        ws.WriteText(row + 1, column, ds.DataSet.Fields[column].AsString);
    end;
    ds.DataSet.Next();
  end;
  ds.DataSet.First();
end;

procedure TMainForm.MenuItemExportClick(Sender: TObject);
var
  MyWorkBook: TsWorkbook;
  header: TStringList;
begin
  if(self.SaveDialogExcel.Execute()) then
  begin
    MyWorkBook := TsWorkbook.Create();
    header := TStringList.Create();

    header.Add('ID');
    header.Add('Name');
    header.Add('Phone_number');
    header.Add('Head_of_department');
    DataSourceToWorksheet(self.DataSourceDepartment, MyWorkBook.AddWorksheet('Department'), header);

    header.Clear();
    header.Add('ID');
    header.Add('Number');
    header.Add('Department_id');
    header.Add('Students_amount');
    header.Add('Average_score');
    header.Add('Group_leader');
    DataSourceToWorksheet(self.DataSourceUniversityGroup, MyWorkBook.AddWorksheet('Universitygroup'), header);

    header.Clear();
    header.Add('ID');
    header.Add('ID_group');
    header.Add('Number_in_group');
    header.Add('Name');
    header.Add('Surname');
    header.Add('Patronymic');
    header.Add('Birth_date');
    header.Add('Address');
    header.Add('Average_score');
    DataSourceToWorksheet(self.DataSourceStudent, MyWorkBook.AddWorksheet('Student'), header);

    header.Clear();
    header.Add('ID');
    header.Add('Name');
    header.Add('Hours_amount');
    header.Add('Hours_of_lectures');
    header.Add('Hours_of_practice');
    header.Add('Number_of_semesters');
    DataSourceToWorksheet(self.DataSourceSubject, MyWorkBook.AddWorksheet('Subject'), header);

    header.Clear();
    header.Add('ID');
    header.Add('Name');
    header.Add('Surname');
    header.Add('Patronymic');
    header.Add('Academic_title');
    header.Add('Id_department');
    DataSourceToWorksheet(self.DataSourceTeacher, MyWorkBook.AddWorksheet('Teacher'), header);

    header.Clear();
    header.Add('ID_student');
    header.Add('ID_group');
    header.Add('ID_subject');
    header.Add('ID_teacher');
    header.Add('Score');
    DataSourceToWorksheet(self.DataSourcePerformance, MyWorkBook.AddWorksheet('Performance'), header);

    MyWorkBook.WriteToFile(self.SaveDialogExcel.FileName, sfExcel8, True);
  end;
end;

procedure TMainForm.MenuItemImportClick(Sender: TObject);
var
  MyWorkBook: TsWorkbook;
  MyWorksheet: TsWorksheet;
  worksheetIndex: Integer;
  row: Cardinal;
  date: TDateTime;
begin
  if(OpenDialogExcel.Execute()) then
  begin
    MyWorkBook := TsWorkbook.Create();
    MyWorkBook.ReadFromFile(OpenDialogExcel.FileName, sfExcel8);

    for worksheetIndex := 0 to MyWorkbook.GetWorksheetCount() - 1 do
    begin
      MyWorksheet := MyWorkbook.GetWorksheetByIndex(worksheetIndex);
      if(MyWorksheet.Name = 'Department') then
      for row := 1 to MyWorksheet.GetLastRowIndex do
      begin
        if (MyWorksheet.ReadAsText(row, 1) = '') or
           (MyWorksheet.ReadAsText(row, 2) = '') or
           (MyWorksheet.ReadAsText(row, 3) = '') then
           continue;
        self.DataSourceDepartment.DataSet.Insert();
        self.DataSourceDepartment.DataSet.Fields[1].AsString := MyWorksheet.ReadAsText(row, 1); // name
        self.DataSourceDepartment.DataSet.Fields[2].AsString := MyWorksheet.ReadAsText(row, 2); // phone_number
        self.DataSourceDepartment.DataSet.Fields[3].AsString := MyWorksheet.ReadAsText(row, 3); // head_of_department
      end;
      if(MyWorksheet.Name = 'Universitygroup') then
      for row := 1 to MyWorksheet.GetLastRowIndex do
      begin
        if (MyWorksheet.ReadAsText(row, 1) = '') or
           (MyWorksheet.ReadAsText(row, 2) = '') or
           (MyWorksheet.ReadAsText(row, 3) = '') or
           (MyWorksheet.ReadAsText(row, 4) = '') or
           (MyWorksheet.ReadAsText(row, 5) = '') then
           continue;
        self.DataSourceUniversityGroup.DataSet.Insert();
        self.DataSourceUniversityGroup.DataSet.Fields[1].AsInteger := trunc(MyWorksheet.ReadAsNumber(row, 1)); // number
        self.DataSourceUniversityGroup.DataSet.Fields[2].AsInteger := trunc(MyWorksheet.ReadAsNumber(row, 2)); // department_id
        self.DataSourceUniversityGroup.DataSet.Fields[3].AsInteger := trunc(MyWorksheet.ReadAsNumber(row, 3)); // students_amount
        self.DataSourceUniversityGroup.DataSet.Fields[4].AsFloat := MyWorksheet.ReadAsNumber(row, 4); // average_score
        self.DataSourceUniversityGroup.DataSet.Fields[5].AsString := MyWorksheet.ReadAsText(row, 5); // group_leader
      end;
      if(MyWorksheet.Name = 'Student') then
      for row := 1 to MyWorksheet.GetLastRowIndex do
      begin
        if (MyWorksheet.ReadAsText(row, 1) = '') or
           (MyWorksheet.ReadAsText(row, 2) = '') or
           (MyWorksheet.ReadAsText(row, 3) = '') or
           (MyWorksheet.ReadAsText(row, 4) = '') or
           (MyWorksheet.ReadAsText(row, 5) = '') or
           (MyWorksheet.ReadAsText(row, 6) = '') or
           (MyWorksheet.ReadAsText(row, 7) = '') or
           (MyWorksheet.ReadAsText(row, 8) = '') then
           continue;
        self.DataSourceStudent.DataSet.Insert();
        self.DataSourceStudent.DataSet.Fields[1].AsInteger := trunc(MyWorksheet.ReadAsNumber(row, 1)); // id_group
        self.DataSourceStudent.DataSet.Fields[2].AsInteger := trunc(MyWorksheet.ReadAsNumber(row, 2)); // number_in_group
        self.DataSourceStudent.DataSet.Fields[3].AsString := MyWorksheet.ReadAsText(row,3); //name
        self.DataSourceStudent.DataSet.Fields[4].AsString := MyWorksheet.ReadAsText(row,4); //surname
        self.DataSourceStudent.DataSet.Fields[5].AsString := MyWorksheet.ReadAsText(row,5); //patronymic
        // birth_date
        MyWorksheet.ReadAsDateTime(row, 6, date);
        self.DataSourceStudent.DataSet.Fields[6].AsDateTime := date;
        self.DataSourceStudent.DataSet.Fields[7].AsString := MyWorksheet.ReadAsText(row, 7); //address
        self.DataSourceStudent.DataSet.Fields[8].AsFloat := MyWorksheet.ReadAsNumber(row, 8); //average_score
      end;
      if(MyWorksheet.Name = 'Subject') then
      for row := 1 to MyWorksheet.GetLastRowIndex do
      begin
        if (MyWorksheet.ReadAsText(row, 1) = '') or
           (MyWorksheet.ReadAsText(row, 2) = '') or
           (MyWorksheet.ReadAsText(row, 3) = '') or
           (MyWorksheet.ReadAsText(row, 4) = '') or
           (MyWorksheet.ReadAsText(row, 5) = '') then
           continue;
        self.DataSourceSubject.DataSet.Insert();
        self.DataSourceSubject.DataSet.Fields[1].AsString := MyWorksheet.ReadAsText(row, 1); // name
        self.DataSourceSubject.DataSet.Fields[2].AsInteger := trunc(MyWorksheet.ReadAsNumber(row, 2)); // hours_amount
        self.DataSourceSubject.DataSet.Fields[3].AsInteger := trunc(MyWorksheet.ReadAsNumber(row, 3)); // hours_of_lectures
        self.DataSourceSubject.DataSet.Fields[4].AsInteger := trunc(MyWorksheet.ReadAsNumber(row, 4)); // hours_of_practice
        self.DataSourceSubject.DataSet.Fields[5].AsInteger := trunc(MyWorksheet.ReadAsNumber(row, 5)); // number_of_semesters
      end;
      if(MyWorksheet.Name = 'Teacher') then
      for row := 1 to MyWorksheet.GetLastRowIndex do
      begin
        if (MyWorksheet.ReadAsText(row, 1) = '') or
           (MyWorksheet.ReadAsText(row, 2) = '') or
           (MyWorksheet.ReadAsText(row, 3) = '') or
           (MyWorksheet.ReadAsText(row, 4) = '') or
           (MyWorksheet.ReadAsText(row, 5) = '') then
           continue;
        self.DataSourceTeacher.DataSet.Insert();
        self.DataSourceTeacher.DataSet.Fields[1].AsString := MyWorksheet.ReadAsText(row, 1); // name
        self.DataSourceTeacher.DataSet.Fields[2].AsString := MyWorksheet.ReadAsText(row, 2); // surname
        self.DataSourceTeacher.DataSet.Fields[3].AsString := MyWorksheet.ReadAsText(row, 3); // patronymic
        self.DataSourceTeacher.DataSet.Fields[4].AsString := MyWorksheet.ReadAsText(row, 4); // academic_title
        self.DataSourceTeacher.DataSet.Fields[5].AsInteger := trunc(MyWorksheet.ReadAsNumber(row, 5)); // id_department
      end;
      if(MyWorksheet.Name = 'Performance') then
      for row := 1 to MyWorksheet.GetLastRowIndex do
      begin
        if (MyWorksheet.ReadAsText(row, 0) = '') or
           (MyWorksheet.ReadAsText(row, 1) = '') or
           (MyWorksheet.ReadAsText(row, 2) = '') or
           (MyWorksheet.ReadAsText(row, 3) = '') or
           (MyWorksheet.ReadAsText(row, 4) = '') then
           continue;
        self.DataSourcePerformance.DataSet.Insert();
        self.DataSourcePerformance.DataSet.Fields[0].AsInteger := trunc(MyWorksheet.ReadAsNumber(row, 0)); // id_student
        self.DataSourcePerformance.DataSet.Fields[1].AsInteger := trunc(MyWorksheet.ReadAsNumber(row, 1)); // id_group
        self.DataSourcePerformance.DataSet.Fields[2].AsInteger := trunc(MyWorksheet.ReadAsNumber(row, 2)); // id_subject
        self.DataSourcePerformance.DataSet.Fields[3].AsInteger := trunc(MyWorksheet.ReadAsNumber(row, 3)); // id_teacher
        self.DataSourcePerformance.DataSet.Fields[4].AsInteger := trunc(MyWorksheet.ReadAsNumber(row, 4)); // score
      end;
    end;
  end;
  if(self.DataSourceDepartment.DataSet.State = dsInsert) then
  self.DataSourceDepartment.DataSet.Post();
  if(self.DataSourcePerformance.DataSet.State = dsInsert) then
  self.DataSourcePerformance.DataSet.Post();
  if(self.DataSourceStudent.State = dsInsert) then
  self.DataSourceStudent.DataSet.Post();
  if(self.DataSourceSubject.DataSet.State = dsInsert) then
  self.DataSourceSubject.DataSet.Post();
  if(self.DataSourceTeacher.DataSet.State = dsInsert) then
  self.DataSourceTeacher.DataSet.Post();
  if(self.DataSourceUniversityGroup.State = dsInsert) then
  self.DataSourceUniversityGroup.DataSet.Post();
end;

procedure TMainForm.MenuItemQuitClick(Sender: TObject);
begin
  Application.Terminate();
end;

procedure TMainForm.MenuItemRefreshClick(Sender: TObject);
begin
  self.RefreshSql();
end;

procedure TMainForm.MenuItemSettingsClick(Sender: TObject);
begin
     FormSettings.ShowModal();
     self.RefreshSettings();
end;

procedure TMainForm.RadioGroupUsersRolesSelectionChanged(Sender: TObject);
begin
  if NOT ((self.PreventRadioGroupUsersRolesRefresh) or (self.RadioGroupUsersRoles.ItemIndex = -1)) then
  begin
    self.PQConnection1.ExecuteDirect('AlTER ROLE"' + self.ListBoxUsers.Items[self.ListBoxUsers.ItemIndex] + '" NOCREATEROLE;');
    self.PQConnection1.ExecuteDirect('REVOKE role_admin FROM "' + self.ListBoxUsers.Items[self.ListBoxUsers.ItemIndex] + '";');
    self.PQConnection1.ExecuteDirect('REVOKE role_operator FROM "' + self.ListBoxUsers.Items[self.ListBoxUsers.ItemIndex] + '";');
    self.PQConnection1.ExecuteDirect('REVOKE role_user FROM "' + self.ListBoxUsers.Items[self.ListBoxUsers.ItemIndex] + '";');

    if(self.RadioGroupUsersRoles.ItemIndex = 0) then
    begin
      self.PQConnection1.ExecuteDirect('ALTER ROLE "' + self.ListBoxUsers.Items[self.ListBoxUsers.ItemIndex] + '" CREATEROLE;');
      self.PQConnection1.ExecuteDirect('GRANT role_admin TO "' + self.ListBoxUsers.Items[self.ListBoxUsers.ItemIndex] + '";');
    end;

    if(self.RadioGroupUsersRoles.ItemIndex = 1) then
    self.PQConnection1.ExecuteDirect('GRANT role_operator TO "' + self.ListBoxUsers.Items[self.ListBoxUsers.ItemIndex] + '";');

    if(self.RadioGroupUsersRoles.ItemIndex = 2) then
    self.PQConnection1.ExecuteDirect('GRANT role_user TO "' + self.ListBoxUsers.Items[self.ListBoxUsers.ItemIndex] + '";');

    self.SQLTransaction1.Commit();
    self.RefreshSql();
  end;
end;

procedure TMainForm.RawSqlSaveClick(Sender: TObject);
begin
  if(self.SaveDialogRawSql.Execute()) then
  begin
    self.RawSqlEdit.Lines.SaveToFile(self.SaveDialogRawSql.FileName);
  end;
end;

procedure TMainForm.ReportDepartmentClick(Sender: TObject);
begin
  self.frReportDepartment.LoadFromFile('department.lrf');
  self.frReportDepartment.ShowReport();
end;

procedure TMainForm.ReportPerformanceClick(Sender: TObject);
begin
  self.frReportPerformance.LoadFromFile('performance.lrf');
  self.frReportPerformance.ShowReport();
end;

procedure TMainForm.ReportTeacherClick(Sender: TObject);
begin
  self.frReportTeacher.LoadFromFile('teacher.lrf');
  self.frReportTeacher.ShowReport();
end;

procedure TMainForm.SQLQueryPerformanceAfterPost(DataSet: TDataSet);
begin
  self.SQLQueryPerformance.ApplyUpdates(0);
  self.SQLTransaction1.Commit();
  self.RefreshSql();
end;

procedure TMainForm.SQLQueryStudentAfterPost(DataSet: TDataSet);
begin
  self.SQLQueryStudent.ApplyUpdates(0);
  self.SQLTransaction1.Commit();
  self.RefreshSql();
end;

procedure TMainForm.SQLQuerySubjectAfterPost(DataSet: TDataSet);
begin
  self.SQLQuerySubject.ApplyUpdates(0);
  self.SQLTransaction1.Commit();
  self.RefreshSql();
end;

procedure TMainForm.SQLQueryTeacherAfterPost(DataSet: TDataSet);
begin
  self.SQLQueryTeacher.ApplyUpdates(0);
  self.SQLTransaction1.Commit();
  self.RefreshSql();
end;

procedure TMainForm.SQLQueryUniversityGroupAfterPost(DataSet: TDataSet);
begin
  self.SQLQueryUniversityGroup.ApplyUpdates(0);
  self.SQLTransaction1.Commit();
  self.RefreshSql();
end;


end.

