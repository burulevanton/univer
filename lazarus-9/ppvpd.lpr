program ppvpd;

{$mode objfpc}{$H+}

uses
  {$IFDEF UNIX}{$IFDEF UseCThreads}
  cthreads,
  {$ENDIF}{$ENDIF}
  LCLTranslator,
  Interfaces,
  fpspreadsheet,
  fpsTypes,
  xlsbiff8,
  SysUtils, // this includes the LCL widgetset
  Forms,FormRawSqlParamUnit, tachartlazaruspkg, UnitLogin, MainFormUnit,
  FormSettingsUnit
  { you can add units after this };

{$R *.res}
procedure InitLang();
  var
    MyWorkBook: TsWorkbook;
    MyWorkSheet: TsWorksheet;
  begin
    MyWorkBook := TsWorkbook.Create();

    if (not FileExists('settings.xls')) then
    begin
      SetDefaultLang('ru');
      exit();
    end;

    MyWorkBook.ReadFromFile('settings.xls', sfExcel8);

    MyWorkSheet := MyWorkBook.GetWorksheetByName('Form');
    if (MyWorkSheet.ReadAsText(2, 1) = 'en') then
      SetDefaultLang('en')
    else
      SetDefaultLang('ru');
  end;

begin
  InitLang();
  RequireDerivedFormResource:=True;
  Application.Initialize;
  Application.CreateForm(TLogin, Login);
  Application.CreateForm(TMainForm, MainForm);
  Application.CreateForm(TFormSettings, FormSettings);
  Application.CreateForm(TFormRawSqlParam, FormRawSqlParam);
  Application.Run;
end.

