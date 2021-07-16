import * as React from "react";
import {useState} from "react";

export interface Auth {
    token: string | null;
    setToken: (token: string | null) => void;
}


export const AuthContext = React.createContext<Auth>(undefined as any);

export const AuthProvider = AuthContext.Provider;
export const AuthConsumer = AuthContext.Consumer;

export function useAuth() {
    const menu = React.useContext(AuthContext);

    if (!menu) {
        console.error("AuthContext is undefined, make sure to use it as child of AuthContext");
    }

    return menu;
}

export interface AuthProps {

}

const Auth: React.FC<AuthProps> = ({children}) => {
    const [token, setToken] = useState<string | null>(null);

    return (
        <AuthProvider value={{
            token: token,
            setToken: setToken
        }}>
            {children}
        </AuthProvider>
    );
};

export default Auth;