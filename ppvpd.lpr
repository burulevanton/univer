program ppvpd;

{$mode objfpc}{$H+}

uses
  {$IFDEF UNIX}{$IFDEF UseCThreads}
  cthreads,
  {$ENDIF}{$ENDIF}
  Interfaces, // this includes the LCL widgetset
  Forms,FormRawSqlParamUnit, tachartlazaruspkg, UnitLogin, MainFormUnit,
  FormSettingsUnit
  { you can add units after this };

{$R *.res}

begin
  RequireDerivedFormResource:=True;
  Application.Initialize;
  Application.CreateForm(TLogin, Login);
  Application.CreateForm(TMainForm, MainForm);
  Application.CreateForm(TFormSettings, FormSettings);
  Application.CreateForm(TFormRawSqlParam, FormRawSqlParam);
  Application.Run;
end.

