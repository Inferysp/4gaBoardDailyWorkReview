import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import './index.css';
import App from './App.jsx';
import AppProvider from './TimerContext.jsx';
import DataProvider from './DataContext.jsx';

createRoot(document.getElementById('root')).render(
<StrictMode>
    <AppProvider>
    <DataProvider>
        <App />
    </DataProvider>
    </AppProvider>
</StrictMode>,
)
