

xsd /c /n:WaterOneFlow.Schema.v1  cuahsiTimeSeries_v1_0.xsd

xsd /c /n:WaterOneFlow.Schema.v1_1  cuahsiTimeSeries_v1_1.xsd

copy .\cuahsiTimeSeries_v1_0.xsd ..\waterOneFlow\documentation\schema\cuahsiTimeSeries.xsd

REM copy .\cuahsiTimeSeries_v1_1.xsd ..\waterOneFlow\documentation\schema\cuahsiTimeSeries_v1_1.xsd