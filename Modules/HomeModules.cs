using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using BandTracker.Objects;

namespace BandTracker
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => {
                return View["index.cshtml"];
            };

            Get["/bands"] = _ => {
                List<Band> allBands = Band.GetAll();
                return View["bands.cshtml", allBands];
            };

            Get["/venues"] = _ => {
                List<Venue> allVenues = Venue.GetAll();
                return View["venues.cshtml", allVenues];
            };

            Get["/band/{id}"] = parameters => {
                Band newBand = Band.Find(parameters.id);
                return View["band.cshtml", newBand];
            };

            Get["/venue/{id}"] = parameters => {
                Venue newVenue = Venue.Find(parameters.id);
                return View["venue.cshtml", newVenue];
            };

            Post["/bands/new"] = _ => {
                Band newBand = new Band(Request.Form["band-name"]);
                newBand.Save();
                List<Band> allBands = Band.GetAll();
                return View["bands.cshtml", allBands];
            };

            Post["/venues/new"] = _ => {
                Venue newVenue = new Venue(Request.Form["venue-name"]);
                newVenue.Save();
                List<Venue> allVenues = Venue.GetAll();
                return View["venues.cshtml", allVenues];
            };

            Get["/venue/delete/{id}"] = parameters => {
                Venue selectedVenue = Venue.Find(parameters.id);
                List<Venue> allVenues = Venue.GetAll();
                return View["venues.cshtml", allVenues];
            };

            Delete["/venue/delete/{id}"] = parameters => {
                Venue selectedVenue = Venue.Find(parameters.id);
                selectedVenue.DeleteVenue();
                List<Venue> allVenues = Venue.GetAll();
                return View["venues.cshtml", allVenues];
            };
        }
    }
}
