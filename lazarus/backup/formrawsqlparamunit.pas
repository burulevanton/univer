unit FormRawSqlParamUnit;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, FileUtil, Forms, Controls, Graphics, Dialogs, ButtonPanel,
  Grids, db, sqldb, Variants;

type

  { TFormRawSqlParam }

  TFormRawSqlParam = class(TForm)
    ButtonPanelDialog: TButtonPanel;
    StringGridMain: TStringGrid;
  private

  public
     procedure Reload(params: TParams);
     procedure Fill(sql: TSQLQuery);
  end;

var
  FormRawSqlParam: TFormRawSqlParam;

implementation

{$R *.lfm}
function FieldTypeToString(t: TFieldType): string;
begin
  if(t = TFieldType.ftUnknown) or (t = TFieldType.ftString) or (t = TFieldType.ftMemo) then
  begin
    FieldTypeToString := 'String';
  end
  else if (t = TFieldType.ftSmallint) or (t = TFieldType.ftInteger) or (t = TFieldType.ftWord) then
  begin
    FieldTypeToString := 'Int';
  end
  else if (t = TFieldType.ftFloat) then
  begin
    FieldTypeToString := 'Float';
  end
  else if (t = TFieldType.ftDate) or (t = TFieldType.ftDateTime) or (t = TFieldType.ftTime) or (t = TFieldType.ftTimeStamp) then
  begin
    FieldTypeToString := 'Date Time';
  end
  else if (t = TFieldType.ftBoolean) then
  begin
    FieldTypeToString := 'Bool';
  end;
end;

procedure TFormRawSqlParam.Reload(params: TParams);
var
  p: TParam;
begin
  while(self.StringGridMain.RowCount > 1) do
  begin
    self.StringGridMain.DeleteRow(1);
  end;
  for p in params do
  begin
    self.StringGridMain.InsertRowWithValues(self.StringGridMain.RowCount, [
      p.Name,
      FieldTypeToString(p.DataType),
      VarToStr(p.Value)
    ]);
  end;
end;

procedure TFormRawSqlParam.Fill(sql: TSQLQuery);
var
  i: integer;
  p: TParam;
  k: string;
  t: string;
  v: string;
begin
  for i := 1 to self.StringGridMain.RowCount - 1 do
  begin
    k := self.StringGridMain.Rows[i][0];
    t := self.StringGridMain.Rows[i][1];
    v := self.StringGridMain.Rows[i][2];
    p := sql.Params.ParamByName(k);
    if (t = 'Int') then
    begin
      p.AsInteger := StrToInt(v);
    end
    else if (t = 'Float') then
    begin
      p.AsFloat := StrToFloat(v);
    end
    else if (t = 'Date Time') then
    begin
      p.AsDate := StrToDate(v);
    end
    else if (t = 'Bool') then
    begin
      p.AsBoolean := StrToBool(v);
    end
    else
    begin
      p.AsString := v;
    end;
  end;
end;
end.

