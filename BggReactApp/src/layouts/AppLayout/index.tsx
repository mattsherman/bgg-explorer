import { NavLink, Outlet } from 'react-router';

import classes from './index.module.css';

export function AppLayout() {
  return (
    <div className={classes['app-layout']}>
      <header className={classes['header']}>
        <h1>
          <NavLink to="/">BGG Explorer</NavLink>
        </h1>
      </header>
      <section className={classes['sidebar']}>
        <div>Sidebar</div>
        <ul>
          <li>
            <NavLink to="/mattsherman/collection">JAM's Collection</NavLink>
          </li>
          <li>
            <NavLink to="/dccircuit/collection">Andy's Collection</NavLink>
          </li>
        </ul>
      </section>
      <main className={classes['main']}>
        <Outlet />
      </main>
      <footer className={classes['footer']}>Footer</footer>
    </div>
  );
}
