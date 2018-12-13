program ppvpd;

{$mode objfpc}{$H+}

uses
  {$IFDEF UNIX}{$IFDEF UseCThreads}
  cthreads,
  {$ENDIF}{$ENDIF}
  Interfaces, // this includes the LCL widgetset
  Forms,FormRawSqlParamUnit, tachartlazaruspkg, UnitLogin, MainFormUnit, SettingsUnit
  { you can add units after this };

{$R *.res}

begin
  RequireDerivedFormResource:=True;
  Application.Initialize;
  Application.CreateForm(TLogin, Login);
  Application.CreateForm(TMainForm, MainForm);
  Application.CreateForm(TFormRawSqlParam, FormRawSqlParam);
  Application.CreateForm(TFormSettings, FormSettings);
  Application.Run;
end.

