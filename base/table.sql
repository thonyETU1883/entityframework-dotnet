--Base de donnee : entity => postgres

CREATE TABLE article (
    idarticle VARCHAR(100) DEFAULT 'article' || nextval('articlesequence')::TEXT PRIMARY KEY,
    nomarticle VARCHAR(100),
    prix DOUBLE PRECISION,
    etat INTEGER
);


CREATE TABLE vente(
    idvente VARCHAR(100) DEFAULT 'vente' || nextval('ventesequence')::TEXT PRIMARY KEY,
    idarticle VARCHAR(100),
    nombre DOUBLE PRECISION,
    FOREIGN KEY(idarticle) REFERENCES article(idarticle)
);