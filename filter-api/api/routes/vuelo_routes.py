from flask_cors import cross_origin
from flask import request, jsonify
from flask import current_app as app

from api.controllers.vuelo_controller import VueloController
from api.middlewares.auth import token_required


@app.route('/api/vuelos', methods=['GET'])
@cross_origin()
@token_required
def get_vuelos():
    print("Hola")
    return jsonify(VueloController.get_all_vuelos())
