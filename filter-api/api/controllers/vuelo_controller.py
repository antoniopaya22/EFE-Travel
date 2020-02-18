
from api.repository.vuelo_repository import VueloRepository


class VueloController:

    @staticmethod
    def get_all_vuelos():
        vuelos = VueloRepository.get_all_vuelos()
        return [x.to_json() for x in vuelos]
