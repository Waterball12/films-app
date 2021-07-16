import React from 'react';
import Homepage from "./views/Homepage";
import Auth from "./components/Auth";
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";

const App = () => {
    return (
        <Router>
            <Auth>
                <Switch>
                    <Route path="/">
                        <Homepage />
                    </Route>
                </Switch>
            </Auth>
        </Router>
    );
};

export default App;
