import { createContext, useState, useContext } from 'react';

export const AppContext = createContext();
export default function AppProvider({ children }) {
    const [timerSum, setTimerSum] = useState(null);
    const value = { timerSum, setTimerSum };
    return (
        <AppContext.Provider value={value}>
            {children}
        </AppContext.Provider>
    );
}