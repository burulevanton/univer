unit UnitLogin;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, FileUtil, Forms, Controls, Graphics, Dialogs, StdCtrls, MainFormUnit;

type

  { TLogin }

  TLogin = class(TForm)
    ButtonLogin: TButton;
    ButtonCancel: TButton;
    TEditLogin: TEdit;
    EditPassword: TEdit;
    LoginLabel: TLabel;
    PassswordLabel: TLabel;
    procedure ButtonCancelClick(Sender: TObject);
    procedure ButtonLoginClick(Sender: TObject);
  private

  public

  end;

var
  Login: TLogin;

implementation

{$R *.lfm}

{ TLogin }



procedure TLogin.ButtonLoginClick(Sender: TObject);
begin
     MainForm.PQConnection1.UserName:=TEditLogin.Text;
     MainForm.PQConnection1.Password:=EditPassword.Text;
     MainForm.Show();
     Hide();
end;

procedure TLogin.ButtonCancelClick(Sender: TObject);
begin
  Application.Terminate();
end;

end.

