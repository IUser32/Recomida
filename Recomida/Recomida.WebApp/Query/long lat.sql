USE Recomida

GO

ALTER TABLE Perfil.Ubicacion
ADD Latitud GEOGRAPHY NOT NULL

GO

ALTER TABLE Perfil.Ubicacion
ADD Longitud GEOGRAPHY NOT NULL

