import { Request, Response } from 'express';
import * as rp from 'request-promise';

export class Auth {

    public isAuth(req: Request, res: Response, next) {
        const tokensapi = process.env.TOKENS_API || 'http://156.35.95.126:5000';
        rp(
            {
                uri: tokensapi + '/verify-token',
                headers: {
                    'Authorization': req.headers.authorization
                }
            }
        ).then(function (repos) {
            next();
        }).catch(function (err) {
            res.status(401).json({"Error": "Invalid token"});
        });
    }

}