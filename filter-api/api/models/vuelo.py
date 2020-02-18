
class Vuelo():

    def __init__(self, origen, destino, fecha_salida, fecha_llegada, personas, precio, aerolinea, enlace):
        self.origen = origen
        self.destino = destino
        self.fecha_salida = fecha_salida
        self.fecha_llegada = fecha_llegada
        self.personas = personas
        self.precio = precio
        self.aerolinea = aerolinea
        self.enlace = enlace

    def to_json(self):
        return {
            "origen": self.origen,
            "destino": self.destino,
            "fecha_salida": self.fecha_salida,
            "fecha_llegada": self.fecha_llegada,
            "personas": self.personas,
            "precio": self.precio,
            "aerolinea": self.aerolinea,
            "enlace": self.enlace,
        }

    def __repr__(self):
        return '<Vuelo {} - {}>'.format(self.origen, self.destino)