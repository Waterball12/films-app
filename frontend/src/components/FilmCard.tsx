import React from 'react';
import {Film} from "../types/Film";
import {Card, CardActions, CardContent, CardMedia, IconButton, Typography} from "@material-ui/core";
import FavoriteIcon from '@material-ui/icons/Favorite';

export interface FilmCardProps {
    id: number;
    name: string;
    rating: number;
    release: Date;
}

const FilmCard = (film: FilmCardProps) => {
    return (
        <Card>
            <CardMedia
                image="https://images.unsplash.com/photo-1626277828338-48bcc0272f1f?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1048&q=80"
                title={film.name}
                style={{height: 0, paddingTop: '56.25%'}}
            />
            <CardContent>
                <Typography variant="body2" color="textSecondary" component="p">
                    {film.name}
                </Typography>
            </CardContent>
            <CardActions disableSpacing>
                <IconButton aria-label="add to favorites">
                    <FavoriteIcon />
                </IconButton>
            </CardActions>
        </Card>
    );
};

export default FilmCard;