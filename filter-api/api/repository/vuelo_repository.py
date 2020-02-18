from api.models.vuelo import Vuelo


class VueloRepository:

    @staticmethod
    def get_all_vuelos():
        vuelos = [
            Vuelo('Asturias', 'Madrid', '2020-08-01T10:00:00', '2020-08-01T16:20:00', 2, 1390.00, 'Iberia', 'enlace'),
            Vuelo('Asturias', 'Barcelona', '2020-08-01T10:00:00', '2020-08-01T16:20:00', 2, 1290.00, 'Vueling', 'enlace'),
            Vuelo('Asturias', 'Malaga', '2020-08-01T10:00:00', '2020-08-01T16:20:00', 2, 890.00, 'Ryanair', 'enlace')
        ]
        return vuelos
