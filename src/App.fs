module App

open Elmish
open Elmish.React
open Feliz
open Feliz.MaterialUI

type State = { Count: int }

type Msg =
    | Increment
    | Decrement

let init() = { Count = 0 }

let update (msg: Msg) (state: State): State =
    match msg with
    | Increment -> { state with Count = state.Count + 1 }
    | Decrement -> { state with Count = state.Count - 1 }

let render (state: State) (dispatch: Msg -> unit) = 

  Html.div [
    Html.button [
      prop.onClick (fun _ -> dispatch Increment)
      prop.text "Increment"
    ]

    Html.button [
      prop.onClick (fun _ -> dispatch Decrement)
      prop.text "Decrement"
    ]

    Html.h1 state.Count
    Mui.button [ button.fullWidth true; prop.text "BCDx"; button.variant.contained; button.color.primary]
    Mui.grid [ 
      grid.container true;
      grid.spacing._2 
      grid.children [
        Mui.grid [ 
          grid.item true 
          grid.xs._12
          grid.children [ Mui.button [ button.fullWidth true; prop.text "BCD"; button.variant.contained; button.color.primary]]
        ]
      ]
    ]
  ]

Program.mkSimple init update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run
