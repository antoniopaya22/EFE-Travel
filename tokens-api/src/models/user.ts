import { Entity, Column, PrimaryGeneratedColumn } from "typeorm";

@Entity()
export class User {

    constructor(username?: string, lastName?: string, hash?: string, salt?: string) {
        this.username = username;
        this.lastName = lastName;
        this.hash = hash;
        this.salt = salt;
    }

    @PrimaryGeneratedColumn()
    id: number;

    @Column()
    username: string;

    @Column()
    lastName: string;

    @Column()
    hash: string;

    @Column()
    salt: string;

}