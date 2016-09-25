use alytalo;
GO

IF OBJECT_ID('sauna', 'U') IS NOT NULL
DROP TABLE sauna;
GO

IF OBJECT_ID('valo', 'U') IS NOT NULL
DROP TABLE valo;
GO

IF OBJECT_ID('talo', 'U') IS NOT NULL
DROP TABLE talo;
GO

Create table Sauna
(
SaunaId			int not null,
Kuvaus			varchar(50) not null,
TaloId			int not null,
Lampotila		float null,
SaunaPaalla		bit null
);
GO

ALTER TABLE sauna   
ADD CONSTRAINT PK_sauna PRIMARY KEY CLUSTERED (saunaid);  
GO

Create table Valo
(
ValoId		int not null,
Kuvaus		varchar(50) not null,
TaloId		int not null,
ValonMaara	float null,
ValoPaalla	bit
);
GO
/*
ALTER TABLE valo
CONSTRAINT FK_taloid FOREIGN KEY (taloid)     
    REFERENCES talo (taloid)     
    ON DELETE CASCADE    
    ON UPDATE CASCADE    


CONSTRAINT FK_taloid FOREIGN KEY (taloid)     
    REFERENCES talo (taloid)     
    ON DELETE CASCADE    
    ON UPDATE CASCADE    
*/

ALTER TABLE valo
ADD CONSTRAINT PK_valo PRIMARY KEY CLUSTERED (valoid);  
GO


Create table Talo
(
TaloId			int not null,
Kuvaus			varchar(50) not null,
NykyLampo		float null,
TavoiteLampo	float null
);
GO

ALTER TABLE talo   
ADD CONSTRAINT PK_talo PRIMARY KEY CLUSTERED (taloid);  
GO