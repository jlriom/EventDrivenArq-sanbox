# SandBox - Document management workflow (Proof of concept)

## Goal

- Implementation of an asyncronous Event based interaction between active components.

## Patterns

- Event driven Architecture (interaction between components)
- Hexagonal Architecture (Internal component design)
- Single Sign On / OpenId Connect 1.0, Auth 2.0
- Identity Server 4.0
- Command and Query Responsability Segregation (CQRS)
- Applied Solid Principles: SRP, OCP, DIP
- Applied Domain Driven Design patterns : Bounded Context, Layered layers, Rich entities, Value objects, Entity Factories, Services, Repositories

## Framework Platform

- Net Core 3.1
- Asp net core 3.1

# Languages

- C#

# Libraries & Technologies

- RabbitMq
- Masstransit
- MediaTR
- Automapper
- Entity Framework Core
- Sql Server
- Serilog



# Functional requirements

- Upload, Download, Delete Documents and update their metadata.
- Only autheticated users can perform these operations.
- Operations are asyncronous so the success or failing operations are communicated to the user via Email.

# Architecture

## Active Components
- Document API (gateway for user interaction + Component interaction Orchestator)
- Blob Storage API (Document storage)
- Console (shared parameters storage + logger collector)
- Emailer
- Identity provider (SSO implemented using Identity Server 4.0)
- Notifier (responsible to send success/fail operation to UI)

## Main Interations

### Upload document

1. Authenticated user uploads a given document
2. Document API starts and orchestates next flow:
  - Document is uploaded to Blob storage
  - Document metadata is stored in sql server database
  - Email is sent to user
  - Notification is sent to the UI

Alternative cases (Compensation procedures)
  - Blob storage fails: 
    - Email is sent to the user informing that the document has not been stored
    - UI Notification is sent to the user informing that the document is not stored

  - Database insert fails: 
    - Blob storage deletion is performed   
    - Email is sent to the user informing that the document has not been stored
    - UI Notification is sent to the user informing that the document is not stored

  - Email fails: 
    - UI Notification is sent to the user informing that the document is stored but it was not possible to sent the email

### Delete document

1. Authenticated user deletes given document
2. Document API starts and orchestates next flow:
  - Document is deleted from Blob storage
  - Document metadata is deleted from sql server database
  - Email is sent to user
  - Notification is sent to the UI

Alternative cases (Compensation procedures)
  - Blob storage fails: 
    - Email is sent to the user informing that the document has not been deleted
    - UI Notification is sent to the user informing that the document is not deleted

  - Database insert fails: 
    - Blob storage insert is performed   
    - Email is sent to the user informing that the document has not been deleted
    - UI Notification is sent to the user informing that the document is not stored

  - Email fails: 
    - UI Notification is sent to the user informing that the document is deleted but it was not possible to sent the email













    




