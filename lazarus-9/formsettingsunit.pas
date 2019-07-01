unit FormSettingsUnit;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, FileUtil, Forms, Controls, Graphics, Dialogs, StdCtrls,
  ExtCtrls, ButtonPanel, fpspreadsheet, fpsTypes, typinfo, LCLTranslator;

type

  { TFormSettings }

  TFormSettings = class(TForm)
    ButtonFont: TButton;
    ButtonFormColor: TButton;
    ButtonDefaultFormColor: TButton;
    ButtonBackgroundSet: TButton;
    ButtonBackgroundClear: TButton;
    ButtonPanelMain: TButtonPanel;
    ButtonRussian: TButton;
    ButtonEnglish: TButton;
    ColorDialogForm: TColorDialog;
    ColorDialogFont: TColorDialog;
    FontDialogFont: TFontDialog;
    ImageBackground: TImage;
    LabelLanguage: TLabel;
    OpenDialogBackground: TOpenDialog;
    procedure ButtonBackgroundClearClick(Sender: TObject);
    procedure ButtonBackgroundSetClick(Sender: TObject);
    procedure ButtonDefaultFormColorClick(Sender: TObject);
    procedure ButtonEnglishClick(Sender: TObject);
    procedure ButtonFontClick(Sender: TObject);
    procedure ButtonFormColorClick(Sender: TObject);
    procedure ButtonRussianClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    procedure SaveToFile();
    procedure LoadFromFile();
    procedure RefreshSettings();
  public

  end;

var
  FormSettings: TFormSettings;

implementation

{$R *.lfm}

{ TFormSettings }

procedure TFormSettings.ButtonFontClick(Sender: TObject);
begin
  self.FontDialogFont.Execute();
  self.ColorDialogFont.Execute();
  self.FontDialogFont.Font.Color:=self.ColorDialogFont.Color;
  self.SaveToFile();
  self.RefreshSettings();
end;

procedure TFormSettings.ButtonDefaultFormColorClick(Sender: TObject);
begin
  self.ColorDialogForm.Color:=clDefault;
  self.SaveToFile();
  self.RefreshSettings();
end;

procedure TFormSettings.ButtonEnglishClick(Sender: TObject);
begin
  self.ButtonEnglish.Enabled:=false;
  self.ButtonRussian.Enabled:=true;
  SetDefaultLang('en');
  self.SaveToFile();
  self.LoadFromFile();
end;

procedure TFormSettings.ButtonBackgroundSetClick(Sender: TObject);
begin
  if (self.OpenDialogBackground.Execute()) then
  begin
    self.SaveToFile();
    self.RefreshSettings();
  end;
end;

procedure TFormSettings.ButtonBackgroundClearClick(Sender: TObject);
begin
  self.OpenDialogBackground.FileName := '';
  self.SaveToFile();
  self.RefreshSettings();
end;

procedure TFormSettings.ButtonFormColorClick(Sender: TObject);
begin
  self.ColorDialogForm.Execute();
  self.SaveToFile();
  self.RefreshSettings();
end;

procedure TFormSettings.ButtonRussianClick(Sender: TObject);
begin
  self.ButtonRussian.Enabled:=false;
  self.ButtonEnglish.Enabled:=true;
  SetDefaultLang('ru');
  self.SaveToFile();
  self.RefreshSettings();
end;

procedure TFormSettings.FormCreate(Sender: TObject);
begin
  self.LoadFromFile();
  self.RefreshSettings();
end;

procedure TFormSettings.SaveToFile();
var
  MyWorkBook: TsWorkbook;
  MyWorkSheet: TsWorksheet;
begin
  MyWorkBook := TsWorkbook.Create();

  MyWorkSheet := MyWorkBook.AddWorksheet('Font');
  MyWorkSheet.WriteText(0, 0, 'Name');
  MyWorkSheet.WriteText(0, 1, self.FontDialogFont.Font.Name);
  MyWorkSheet.WriteText(1, 0, 'Size');
  MyWorkSheet.WriteNumber(1, 1, self.FontDialogFont.Font.Size);
  MyWorkSheet.WriteText(2, 0, 'Style');
  MyWorkSheet.WriteText(2, 1, SetToString(GetPropInfo(self.FontDialogFont.Font, 'Style'),
    integer(self.FontDialogFont.Font.Style), False));
  MyWorkSheet.WriteText(3, 0, 'Color');
  MyWorkSheet.WriteNumber(3, 1, self.FontDialogFont.Font.Color);

  MyWorkSheet := MyWorkBook.AddWorksheet('Form');
  MyWorkSheet.WriteText(0, 0, 'Color');
  MyWorkSheet.WriteNumber(0, 1, self.ColorDialogForm.Color);
  MyWorkSheet.WriteText(1, 0, 'Image');
  MyWorkSheet.WriteText(1, 1, self.OpenDialogBackground.FileName);
  MyWorkSheet.WriteText(2, 0, 'Language');
  if (self.ButtonRussian.Enabled) then
    MyWorkSheet.WriteText(2, 1, 'en');
  if (self.ButtonEnglish.Enabled) then
    MyWorkSheet.WriteText(2, 1, 'ru');

  MyWorkBook.WriteToFile('settings.xls', sfExcel8, True);
end;

procedure TFormSettings.LoadFromFile();
var
  MyWorkBook: TsWorkbook;
  MyWorkSheet: TsWorksheet;
begin
  MyWorkBook := TsWorkbook.Create();

  if (not FileExists('settings.xls')) then
  begin
    self.ButtonEnglish.Enabled:=true;
    self.ButtonRussian.Enabled:=false;
    exit();
  end;

  MyWorkBook.ReadFromFile('settings.xls', sfExcel8);

  MyWorkSheet := MyWorkBook.GetWorksheetByName('Font');
  self.FontDialogFont.Font := Font.Create();
  self.FontDialogFont.Font.Name := MyWorkSheet.ReadAsText(0, 1);
  self.FontDialogFont.Font.Size := trunc(MyWorkSheet.ReadAsNumber(1, 1));
  self.FontDialogFont.Font.Style :=
    TFontStyles(StringToSet(GetPropInfo(self.FontDialogFont.Font, 'Style'),
    MyWorkSheet.ReadAsText(2, 1)));
  self.FontDialogFont.Font.Color := trunc(MyWorkSheet.ReadAsNumber(3, 1));
  self.ColorDialogFont.Color := self.FontDialogFont.Font.Color;

  MyWorkSheet := MyWorkBook.GetWorksheetByName('Form');
  self.ColorDialogForm.Color := trunc(MyWorkSheet.ReadAsNumber(0, 1));
  self.OpenDialogBackground.FileName := MyWorkSheet.ReadAsText(1, 1);
  if (MyWorkSheet.ReadAsText(2, 1) = 'en') then
    begin
      self.ButtonEnglish.Enabled:=false;
      self.ButtonRussian.Enabled:=true;
    end
  else
    begin
      self.ButtonEnglish.Enabled:=true;
      self.ButtonRussian.Enabled:=false;
    end;
end;

procedure TFormSettings.RefreshSettings();
begin
  self.Font := self.FontDialogFont.Font;
  self.Color := self.ColorDialogForm.Color;
  if FileExists(self.OpenDialogBackground.FileName) then
    self.ImageBackground.Picture.LoadFromFile(self.OpenDialogBackground.FileName)
  else
    self.ImageBackground.Picture.Clear();
end;

end.

