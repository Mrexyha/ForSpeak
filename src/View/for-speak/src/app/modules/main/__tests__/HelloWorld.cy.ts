import MainComponent from '../components/MainComponent.vue'

describe('HelloWorld', () => {
  it('playground', () => {
    cy.mount(MainComponent, { props: { msg: 'Hello Cypress' } })
  })

  it('renders properly', () => {
    cy.mount(MainComponent, { props: { msg: 'Hello Cypress' } })
    cy.get('h1').should('contain', 'Hello Cypress')
  })
})
