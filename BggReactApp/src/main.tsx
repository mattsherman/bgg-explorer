import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import { BrowserRouter, Route, Routes } from 'react-router';

import { AppLayout } from './layouts/AppLayout';
import { AppHome } from './pages/AppHome';
import { UserCollection } from './pages/UserCollection';

import './index.css';

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <BrowserRouter>
      <Routes>
        <Route element={<AppLayout />}>
          <Route index element={<AppHome />} />
          <Route
            path="/user/:username/collection"
            element={<UserCollection />}
          />
        </Route>
      </Routes>
    </BrowserRouter>
  </StrictMode>
);
