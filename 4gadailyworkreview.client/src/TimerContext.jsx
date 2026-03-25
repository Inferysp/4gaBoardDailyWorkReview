import { createContext, useState, useContext } from 'react';

export const TimerContext = createContext();
export default function AppProvider({ children }) {
    const [timerSum, setTimerSum] = useState(null);
    const value = { timerSum, setTimerSum };
    return (
        <TimerContext.Provider value={value}>
            {children}
        </TimerContext.Provider>
    );
}