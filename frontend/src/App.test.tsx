// App.test.tsx
import { render, screen } from '@testing-library/react';
import App from './App';

// Test suite for App component
describe('App component', () => {
  test('renders the learn react link', () => {
    // Render the App component
    render(<App />);

    // Check if an element with the text 'learn react' is found
    const linkElement = screen.getByText(/learn react/i);
    expect(linkElement).toBeInTheDocument();
  });
});
