import { NavLink, Outlet } from 'react-router';

export function AppLayout() {
  return (
    <div>
      <header>
        <h1>
          <NavLink to="/">BGG Explorer</NavLink>
        </h1>
      </header>
      <section>
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
      <main>
        <Outlet />
      </main>
      <footer>Footer</footer>
    </div>
  );
}
